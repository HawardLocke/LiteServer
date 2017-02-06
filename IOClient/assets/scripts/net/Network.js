
var littleEndian = false;

const MsgHandler = require('MsgHandler');

var Network = {

	websock:null,

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

		littleEndian = (function() {
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
		//cc.log("NetWork msg......");
		MsgHandler.OnMessage(e.data, littleEndian);
	},

	onError:function(e){
		cc.log("NetWork error......");
	},

	onclose:function()
    {
		cc.log("Connection is closed...");
    },

	send:function(msgID, buffer) {
		if (this.websock != null && this.websock.readyState == WebSocket.OPEN){
			var data = buffer;
			var dataLen = data.byteLength;
			var length = dataLen + 4 + 4;
			cc.log('data ' + dataLen + ', total '+length);
			var buffer = new ArrayBuffer(length);
			var dv = new DataView(buffer);

			dv.setInt32(0, msgID, littleEndian);
			dv.setInt32(4, dataLen, littleEndian);
			for (var i = 0; i < dataLen; i++) {
				dv.setInt8(8+i, data[i]);
				//cc.log(''+data[i]);
			}

			this.websock.send(buffer);
		}
	}

};

module.exports = Network;