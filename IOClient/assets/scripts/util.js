
var util = {};

util.getStringFromFile = function(file){
    /*if (cc.sys.isNative){
        return jsb.fileUtils.getStringFromFile(file);
    }else{*/
        return cc.loader._loadTxtSync(file);
    //}
}

module.exports = util;