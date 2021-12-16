

const READ = "read";
const SEND = "post";
const READ_COMMANDS = "read_settings";
const SEND_COMMANDS = "set_settings";

function checkAccess(token, accessLevel, cb) {
    if (token in tokens && tokens[token][accessLevel]==true) 
        cb(token, accessLevel, true); 
    else 
        cb(token, accessLevel, false);
}

function accessLevel(read_packets, post_packets, get_settings, set_settings) {
    var res = {};
    res[READ] = read_packets;
    res[SEND] = post_packets; 
    res[READ_COMMANDS] = get_settings; 
    res[SEND_COMMANDS] = set_settings;
    return res;
}

var tokens = { 
    'e4127d1886e380dd4715e0cd7d5d2fb98f572ea4': accessLevel(true, false, false, false), // sha1 hash for 'tion-iot-core-read'
    '92d1f7c3375a786ff565aa6a8c0ad50049b0fd57': accessLevel(false, true, false, false), // sha1 hash for 'tion-iot-core-post-packets'
    'eb84570f955cf879861c7045a261945aa900acb0': accessLevel(false, false, true, false), // sha1 hash for 'tion-iot-core-get-control'
    '500e082ab4d8dc42cff08a8e1515cb5ddde8156b': accessLevel(false, false, false, true), // sha1 hash for 'tion-iot-core-control'
    '30f1abb9a849ae3aa4f71544ff773ec9e19e2f4f': accessLevel(true, true, true, true), // sha1 hash for 'tion-iot-core-master'
    // keys from specs
    '7JElOsKIpD6s0oDm2nd7': accessLevel(true, false, false, false), // only read packets
    'J3UK0ex9RUVhzgFi9BeI': accessLevel(false, true, false, false), // only post packets
    'oH9Wcvkp116UQ41b0A0x': accessLevel(false, false, true, false), // only read commands
    '9XYpgKdR7zCfSWbQoU16': accessLevel(false, false, false, true)  // only post commands
};

module.exports = {
    READ: READ,
    SEND: SEND,
    READ_COMMANDS: READ_COMMANDS,
    SEND_COMMANDS: SEND_COMMANDS,
    
    check: checkAccess
};
