"use strict";
var express = require('express');
var bodyParser = require('body-parser');
var logger = require('./logging.js');


var app = express();


var access = require('./access.js');
var db = require('./db.js');

app.use(bodyParser.json());
app.use('/static', express.static('static'));
app.use(logger.morgan);

var startDate = new Date();

function sendResponse(res, desc) {
    if(desc === undefined) {
        res.json( {result:"ok"} );
    } else {
        res.json( {result:"err", desc:String(desc) } );
    }
}

app.post('/postPacket', function(req, res) {
    var time0 = process.hrtime();
    
    access.check(req.query.authkey, access.SEND, (t,a,access) => {
        if(! access) {
            sendResponse(res, 'not_authorised');
            logger.warn('token '+t+' does not fit to '+a);
            return;
        }
        
        var packet = req.body;
        
        //* ensure data types:
        if( typeof packet.node != 'number' || Math.round(packet.node)!==packet.node) {
            sendResponse(res, 'bad_node_id');
            logger.warn('request to post bad node id '+packet.node+' of type '+(typeof packet.node) );
            return;
        }
        if( typeof packet.protocol != 'string') {
            sendResponse(res, 'bad_protocol_type');
            logger.warn('request to post bad protocol type '+(typeof packet.protocol) );
            return;
        }
        if( typeof packet.type != 'string') {
            sendResponse(res, 'bad_type_type');
            logger.warn('request to post bad type of type '+(typeof packet.protocol) );
            return;
        }
        
        //* the only protocol supported
        if(packet.protocol !== 'cityair') {
            sendResponse(res, 'wrong_protocol');
            logger.warn('wrong protocol: '+packet.protocol);
            return;
        }
        
        db.insertPacket(packet, (errDesc, err, pack)=> {
            if(err) {
                sendResponse(res, err);
                logger.warn(errDesc);
                return;
            }
            
            sendResponse(res);
            logger.debug('postPacket added one element: '+ pack.protocol+'/'+pack.node+'/'+pack.timestamp);
            var dt = process.hrtime(time0);
            logger.verbose('postPacket took '+ (dt[0]*1000 + dt[1]/1000000)+'ms' );
        });
    } );
});

function getGeoJSONRect(req) {
    var lat1 = Math.min(req.query.lat1, req.query.lat2);
    var lat2 = Math.max(req.query.lat1, req.query.lat2);
    var lon1 = Math.min(req.query.lon1, req.query.lon2);
    var lon2 = Math.max(req.query.lon1, req.query.lon2);
    return { type: 'Polygon', coordinates: [ [ [lon1,lat1], [lon2,lat1], [lon2,lat2], [lon1,lat2], [lon1,lat1] ] ] };
}

app.get('/getPackets', function (req, res) {
    var time0 = process.hrtime();

    access.check(req.query.authkey, access.READ, (t,a,access) => {
        if(! access) {
            sendResponse(res, 'not_authorised');
            logger.warn('token '+t+' does not fit to '+a);
            return;
        }
        var q = req.query;

        var haveTime = 'after' in q && 'before' in q;
        var haveLoc = 'lat1' in q;
        var haveNode = 'node' in q;
        var haveType = 'type' in q;
        
        /** Now filter invalid requests. 
         * Acceptable requests are:
         * 1. proto,            loc
         * 2. proto,      type, loc
         * 3. proto, node
         * 4. proto,            loc, time
         * 5. proto,      type, loc, time
         * 6. proto, node,           time
         */
        
        if (! ('protocol' in q) ) {
            sendResponse(res, 'no_protocol_specified');
            logger.warn('getPackets without protocol');
            return;
        }
        
        var valid = 
            !haveNode && !haveType &&  haveLoc && !haveTime ||
            !haveNode &&  haveType &&  haveLoc && !haveTime ||
             haveNode && !haveType && !haveLoc && !haveTime ||
            !haveNode && !haveType &&  haveLoc &&  haveTime ||
            !haveNode &&  haveType &&  haveLoc &&  haveTime ||
             haveNode && !haveType && !haveLoc &&  haveTime ;
        if (!valid) {
            sendResponse(res, 'wrong_set_of_request_fields');
            logger.warn('getPackets wrong set of fields');
            return;
        }
        
        var hot = ! haveTime; 
        
        var filter = {};
        var sort = {};
        
        // protocol specified. if is always true
        if('protocol' in q) {
            filter.protocol = q.protocol;
        }
        
        // node id specified
        if(haveNode) {
            filter.node = Number(q.node);
            // for node, sort results by date
            sort.date = 1;
        }
        
        // type is specified
        if(haveType) {
            filter.type = q.type;
        }
        
        // we have spatial limits
        if( haveLoc ) {
            filter.location = {
                $geoWithin : { $geometry: getGeoJSONRect(req) }
            };
        }
        
        // temporal limits specified
        if(haveTime) {
            var d1 = new Date( q.after ); // earlier date
            var d2 = new Date( q.before ); // later date
            filter.date =  { $gt: d1, $lt: d2 };
            // for time query, sort by date
            sort.date = 1;
        } 
        
        logger.debug('getPackets filter is %j',filter, {} );
        
        db.getPackets(hot, filter, sort, (err, errDesc, data) => {
            if(err) {
                sendResponse(res, errDesc);
                logger.warn(err);
                return;
            }
            
            logger.debug('getPackets returned '+ data.length+' packets');
            res.json( {result:'ok', packets:data});
            
            var dt = process.hrtime(time0);
            logger.verbose('getPackets took '+ (dt[0]*1000 + dt[1]/1000000)+'ms' );
        });
    });
});

app.post('/postCommandBlock', function(req, res) {
    
    access.check(req.query.authkey, access.SEND_COMMANDS, (t,a,access) => {
        if(! access) {
            sendResponse(res, 'not_authorised');
            logger.warn('token '+t+' does not fit to '+a);
            return;
        }
        
        var packet = req.body;
        
        //* check important fields
        if( typeof packet.node != 'number' || Math.round(packet.node)!==packet.node) {
            sendResponse(res, 'bad_node_id');
            logger.warn('request to post bad node id '+packet.node+' of type '+(typeof packet.node) );
            return;
        }
        if( typeof packet.protocol != 'string') {
            sendResponse(res, 'bad_protocol_type');
            logger.warn('request to post bad protocol type '+(typeof packet.protocol) );
            return;
        }
        
        
        //* the only protocol supported
        if(packet.protocol !== 'cityair') {
            sendResponse(res, 'wrong_protocol');
            logger.warn('wrong protocol: '+packet.protocol);
            return;
        }

        db.insertCommandBlock(packet, (err, errDesc, pack) => {
            if(err) {
                sendResponse(res, errDesc);
                logger.warn(err);
                return;
            }

            res.json( {result:'ok', 'registered_as': pack._id});
        });
    } );
        
});

app.get('/getCommandBlock', function(req, res) {
    access.check(req.query.authkey, access.READ_COMMANDS, (t,a,access) => {
        if(! access) {
            sendResponse(res, 'not_authorised');
            logger.warn('token '+t+' does not fit to '+a);
            return;
        }

        var proto = req.query.protocol;
        var node = Number(req.query.node);
        
        if( proto == undefined || node == undefined) {
            sendResponse(res, 'wrong_set_of_request_fields');
            logger.warn('bad request: proto='+proto+', node='+node);
            return;
        }
        
        db.getOldestCommandBlock(proto, node, (err, errDesc, packet) => {
            if(err) {
                sendResponse(res, errDesc);
                logger.warn(err);
                return;
            }
            
            logger.debug('getCommandBlock returned '+ (packet==undefined ? 'nothing' : ' 1 block') );
            res.json( {result:'ok', block: (packet==undefined ? null : packet) } );
        } );
    } );
} );

app.get('/removeCommandBlock', function(req, res) {
    access.check(req.query.authkey, access.READ_COMMANDS, (t,a,access) => {
        if(! access) {
            sendResponse(res, 'not_authorised');
            logger.warn('token '+t+' does not fit to '+a);
            return;
        }
        
        var proto = req.query.protocol;
        var node = Number(req.query.node);
        var date = new Date(req.query.timestamp);
        if( proto == undefined || node == undefined || date == undefined) {
            sendResponse(res, 'wrong_set_of_request_fields');
            logger.warn('bad request: proto='+proto+', node='+node+', date:'+date);
            return;
        }
        db.removeOldestCommandBlock( proto, node, date, (err, errDesc) => {
            if(err) {
                sendResponse(res, errDesc);
                logger.warn(err);
                return;
            }
            
            logger.debug('removeCommandBlock ok' );
            sendResponse(res);
        });
    } );
} );


app.get('/status', function(req,res) {
    var stat = {};
    stat.result = 'ok';
    stat.uptime = ( new Date().getTime() - startDate.getTime() ) / 1000.0;
    res.json( stat ); 
});

db.init( function(err) {
    if(err) {
        logger.error('mongo init error: ' + err);
        return;
    }

    logger.info('mongodb connected');
    
    var port = process.env.PORT || 8080;
    app.listen(port, function () {
        logger.info('http server started at port '+port);
    });
});

