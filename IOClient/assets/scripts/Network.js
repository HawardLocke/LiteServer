


var Network = {

	websock:null,
	msgHandlers:{},

	init:function(){
		cc.log("NetWork try connect......");
		var ws_url = "ws://127.0.0.1:8866";
		this.websock = new WebSocket(ws_url);
		this.websock.binaryType = "arraybuffer";
		this.websock.onopen = this.onOpen;
		this.websock.onmessage = this.onMessage;
		this.websock.onerror = this.onError;
	},

	onOpen:function(e){
		cc.log("NetWork open success......");
		const MsgSender = require('MsgSender');
		MsgSender.SendLogin(MsgSender.name, MsgSender.pswd);
	},

	onMessage:function(e) {
		cc.log("NetWork msg......");
		/*json = JSON.parse(e.data);
		if (!(json[0] instanceof Array))
			json = [json];

		for (var i = 0; i < json.length; i++) {
			var args = json[i];
			var cmd = json[i][0];
			var handlers = NetWork.msgHandlers[cmd];
			if (handlers != undefined){
				handlers(args);
			}
		}*/
	},

	onError:function(e){
		cc.log("NetWork error......");
	},

	send:function(msgID, data) {
		if (this.websock != null && this.websock.readyState == WebSocket.OPEN){
			this.websock.send(data);
		}
		else {
			cc.log("Network.send: socket is closed");
		}
	},

	registHandler:function(msgID, handler){
		if (typeof msgID === 'number' && handler instanceof Function){
			this.msgHandlers[msgID] = handler;
		}
	}

};

module.exports = Network;