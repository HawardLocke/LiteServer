


var Network = {

	websock:null,
	msgHandlers:{},

	littleEndian:false,


	ConnectServer:function(){
		if (this.websock != null)
			return;
		
		cc.log("NetWork try connect......");
		var ws_url = "ws://127.0.0.1:8866";
		this.websock = new WebSocket(ws_url);
		this.websock.binaryType = "arraybuffer";
		this.websock.onopen = this.onOpen;
		this.websock.onmessage = this.onMessage;
		this.websock.onerror = this.onError;
		this.websock.onclose = this.onclose;

		this.littleEndian = (function() {
			var buffer = new ArrayBuffer(2);
			new DataView(buffer).setInt16(0, 256, true);
			return new Int16Array(buffer)[0] === 256;
		})();

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

	onclose:function()
    {
		cc.log("Connection is closed...");
    },

	send:function(msgID, msg) {
		if (this.websock != null && this.websock.readyState == WebSocket.OPEN){
			var data = msg.encodeAB();
			var dataLen = data.byteLength;
			var length = dataLen + 4 + 4;
			cc.log('data ' + dataLen + ', total '+length);
			var buffer = new ArrayBuffer(length);
			var dv = new DataView(buffer);

			var littleEndian = require('Network').littleEndian;
			
			dv.setInt32(0, msgID, littleEndian);
			dv.setInt32(4, dataLen, littleEndian);
			for (var i = 0; i < dataLen; i++) {
				dv.setInt8(8+i, data[i]);
				cc.log(''+data[i]);
			}

			/*var head = new Int32Array(buffer, 0, 12);
			head[0] = msgID;
			head[1] = dataLen;
			var tail = new Int8Array(buffer, 8);
			for (var i = 0; i < tail.length; i++) {
				tail[i] = data[i];
			}*/
			
			this.websock.send(buffer);
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