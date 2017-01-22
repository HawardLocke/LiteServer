cc.Class({
    extends: cc.Component,

    properties: {
        
    },

    // use this for initialization
    onLoad: function () {
        var Protocol = require('Protocol');
        Protocol.Init();
    },

    // called every frame, uncomment this function to activate update callback
    // update: function (dt) {

    // },
});
