

var mongo = require('mongodb').MongoClient;

var logger = require('./logging.js');

var db = null;


function ensureIndices( cb ) {
    // indices for reports
    
    var packets = db.collection('packets');
    var hotpackets = db.collection('hotpackets');
    var commands = db.collection('commands');

    logger.info('Index creation for packets db');
    Promise.all( [
        packets.ensureIndex( {location: '2dsphere'} ),
        packets.ensureIndex( {protocol: 1} ),
        packets.ensureIndex( {type: 1} ),
        packets.ensureIndex( {date: 1} ),
        packets.ensureIndex( {node: 1} ), 
        // compound indices for requests
        packets.ensureIndex( {protocol:1, location: '2dsphere', date:1} ),
        packets.ensureIndex( {protocol:1, type:1, location: '2dsphere', date:1} ),
        packets.ensureIndex( {protocol:1, node:1, date:1}  ),
    ] ) .then( idx => logger.debug(' "packet" indices: '+ idx) )
        .then( ()=>{
            logger.info('Index creation for hotpackets cache db');
            return Promise.all( [
                // create indices for hot packets
                hotpackets.ensureIndex( {location: '2dsphere'} ),
                hotpackets.ensureIndex( {node: 1} ),
                hotpackets.ensureIndex( {protocol: 1} ),
                hotpackets.ensureIndex( {type: 1} ),
                // compound indices for requests
                hotpackets.ensureIndex( {protocol:1, location:'2dsphere'} ),
                hotpackets.ensureIndex( {protocol:1, type:1, location:'2dsphere'} ),
                // this one is also used for upserting packets
                hotpackets.ensureIndex( {protocol:1, node:1}, {unique:true} )
            ] );
        } )
        .then( idx => logger.debug(' "hotpacket" indices: '+ idx) )
        .then( ()=> {
            logger.info('Index creation for settings db');
            return commands.ensureIndex( {protocol:1, node:1, date:1}, {unique:true} );
        })
        .then( idx => logger.debug(' "commands" indices: '+ idx) )
        .then( ()=> cb() )
        .catch( cb );
        

}

function init(cb) {
    mongo.connect('mongodb://localhost:27017/tiondb', function(err, db_) {
        if(err) {
            cb(err);
            return;
        }
        
        db = db_;
        ensureIndices(cb);
    });
}

function stripPacket(packet) {
    delete packet._id;
    delete packet.date;
    delete packet.location;
}

//******************************************************************************
//***
//***                      Add/get packets
//***
//******************************************************************************


function insertPacket(packet, cb) {
    if (!db) {
        cb('db probably not connected yet', 'no_db');
        return;
    }
    
    //* add mongo-related fields for indices
    //* create a Date object for date filtering
    packet.date = new Date();
    packet.timestamp = packet.date.toISOString();
    //* create fancy-looking _id
    packet._id = packet.protocol+'/'+packet.node+'/'+packet.timestamp;
    
    //* create a GeoJSON object of type 'Point' for 2dsphere index to work.
    packet.location = { type: "Point", coordinates: [ packet.values.LNG, packet.values.LAT] };

    db.collection('packets').insert(packet, function(err, result) {
        if(err) {
            cb(err, 'db_insert_failed');
            return;
        }
        // insertion ok
        
        packet._id = packet.protocol+'/'+packet.node;
        db.collection('hotpackets').update({node:packet.node, protocol:packet.protocol}, packet, {upsert: true}, (err, result)=> {
            if(err) {
                cb(err, 'db_upsert_failed');
                return;
            }
            // insertion ok
            cb(null,null,packet);
        } );
        
    } );
}


function getPackets(hot, filter, sort, cb) {
    if (!db) {
        cb('db probably not connected yet', 'no_db');
        return;
    }
    var coll = hot ? db.collection('hotpackets') : db.collection('packets');
    getPacketsRaw( coll, filter, sort, cb );
}

function getPacketsRaw(coll, filter, sort, cb) {
    // debug run of the query and output execution plan
    //coll.find(filter).sort(sort).explain( (e,t)=> logger.log(t) ) ;
    coll.find(filter).sort(sort).toArray( (err,data)=>{
        if(err) {
            cb(err, 'db_query_failed');
            return;
        }
        
        for(var i = 0; i < data.length; i++) stripPacket( data[i] );
        
        cb(undefined, undefined, data);
        
    });
}

//******************************************************************************
//***
//***                      Settings block save/retrieve
//***
//******************************************************************************

function insertCommandBlock(packet, cb) {
    if (!db) {
        cb('db probably not connected yet', 'no_db');
        return;
    }
    
    //* add mongo-related fields for indices
    //* create a Date object for date filtering
    packet.date = new Date();
    packet.timestamp = packet.date.toISOString();
    //* create fancy-looking _id
    packet._id = packet.protocol+'/'+packet.node+'/'+packet.timestamp;
    
    db.collection('commands').insert(packet, function(err, result) {
        if(err) {
            cb(err, 'db_insert_failed');
            return;
        }
        // insertion ok
        
        cb(undefined, undefined, packet);
        
    } );
}

function getOldestCommandBlock(proto, node, cb) {
    if (!db) {
        cb('db probably not connected yet', 'no_db');
        return;
    }
    
    db.collection('commands')
        .findOne({protocol:proto, node:node}, {sort:{date:1}}, (err,data)=> {
        //.sort({date:1})
        //.limit(1)
        //.toArray( (err,data)=> {
            if(err) {
                cb(err, 'db_query_failed');
                return;
            }
            if(!data) {
                cb(null, null, null);
                return;
            }
            stripPacket( data );
            cb(null, null, data );
        }
    );
}
/** date is required to match date of to-be-deleted block. otherwise anyone could delete is too easily. */
function removeOldestCommandBlock(proto, node, date, cb) {
    if (!db) {
        cb('db probably not connected yet', 'no_db');
        return;
    }
    
    db.collection('commands').findOne({protocol:proto, node:node}, {fields:{timestamp:1}, sort:{date:1}}, (err,data)=> {
        if(err) {
            cb(err, 'db_find_err');
            return;
        }
        if(!data) {
            cb('command not found', 'commandblock_not_found');
            return;
        }
        if( data.timestamp != date.toISOString() ) {
            cb('supplied date is not oldest', 'date_not_oldest');
            return;
        }
        db.collection('commands').deleteOne( {protocol:proto, node:node, date:date}, (err,r)=> {
            if(err) {
                cb(err, 'db_delete_failed');
                return;
            }
            cb();
        } );
    })

}


module.exports = {
    init: init,
    
    insertPacket: insertPacket,
    getPackets: getPackets,
    
    insertCommandBlock: insertCommandBlock,
    getOldestCommandBlock: getOldestCommandBlock,
    removeOldestCommandBlock: removeOldestCommandBlock
    
};
