
var util = {};

util.getStringFromFile = function(file){
    /*if (cc.sys.isNative){
        return jsb.fileUtils.getStringFromFile(file);
    }else{*/
        return cc.loader._loadTxtSync(file);
    //}
};

util.log = function(text){
    cc.log('--'+text);
};

module.exports = util;