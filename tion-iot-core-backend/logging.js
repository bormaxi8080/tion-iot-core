
'use strict'
var winston = require('winston');
var morgan = require('morgan');
var dateFormat = require('dateformat');

winston.emitErrs = true;

/**
 * Formats a log message
 */
var fmt = function(options) {
    var formatted='';
    if (options.timestamp) formatted += dateFormat( options.timestamp(), 'yyyy/mm/dd HH:MM:ss ' );
    if (options.showLevel) {
        if(options.colorize) 
            formatted += '[' +winston.config.colorize(options.level) + '] ';
        else 
            formatted += '['+options.level+'] ';
    }
    formatted += options.message;
    
    return formatted;
};

//* default file logger
var transports = [
        new winston.transports.File({
            level: 'debug',
            filename: './logs/app.log', // might not be writable if production is run under different user.
            handleExceptions: true,
            json: false,
            maxsize: 5*1024*1024, //5MB
            maxFiles: 10,
            colorize: false,
            formatter: fmt,
            timestamp: Date.now
        })
    ];
    
var env = process.env.NODE_ENV || 'dev';
if (env !== 'production') {
    // add console logger
    transports.push( new winston.transports.Console({
            level: 'debug',
            handleExceptions: true,
            json: false,
            colorize: true,
            formatter: fmt,
            timestamp: Date.now
        }) );
}

var logger = new winston.Logger({
    transports: transports,
    exitOnError: false
});

var stream = {
    write: function(message, encoding) { 
        logger.info(message.replace(/\n$/, "") ); 
    }
};
 

module.exports = logger;
module.exports.morgan = morgan(
    ':remote-addr :remote-user ":method :url HTTP/:http-version" :status :res[content-length] ":user-agent"',
    { 'stream': stream });

