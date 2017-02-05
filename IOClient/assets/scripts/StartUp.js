
const Game = require('Game');

cc.Class({
    extends: cc.Component,

    properties: {
        
    },

    // use this for initialization
    onLoad: function () {
        Game.Init();
        //var Protocol = require('Protocol');
        //Protocol.Init();
    },

    // called every frame, uncomment this function to activate update callback
    // update: function (dt) {

    // },
});
