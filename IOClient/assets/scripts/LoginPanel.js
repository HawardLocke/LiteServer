
const Network = require('Network');
const MsgSender = require('MsgSender');

cc.Class({
    extends: cc.Component,

    properties: {
        
    },

    // use this for initialization
    onLoad: function () {
        this.startBtn = cc.find("Canvas/userInfo/play").getComponent(cc.Button);
		this.startBtn.node.on(cc.Node.EventType.TOUCH_END, this.OnStartButtonTouch, this);
        this.nameInput = cc.find("Canvas/userInfo/nameEdit").getComponent(cc.EditBox);
		this.codeInput = cc.find("Canvas/userInfo/pswdEdit").getComponent(cc.EditBox);
		this.nameInput.string = 'Locke';
		this.codeInput.string = '******';
    },

    // called every frame, uncomment this function to activate update callback
    // update: function (dt) {

    // },

    OnStartButtonTouch:function(event) {
		var button = event.detail;
        //cc.log('click');
        Network.ConnectServer();
        MsgSender.name = this.nameInput.string;
        MsgSender.pswd = this.codeInput.string;
	}

});
