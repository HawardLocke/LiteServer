
const Network = require('Network');

const MsgID = require('./protobuf/MsgID');
var login_pb = require('./protobuf/login_pb');
var scene_pb = require('./protobuf/scene_pb');
var chat_pb = require('./protobuf/chat_pb');

var MsgHandler = {

	msgHandlers:{},

	Init:function(){
		this.registHandler(MsgID.scLoginRet, this.onLoginRet);
	},

	registHandler:function(msgID, handler){
		if (typeof msgID === 'number' && handler instanceof Function){
			this.msgHandlers[msgID] = handler;
		}
	},

	OnMessage:function(buffer, littleEndian){
		var dv = new DataView(buffer);
		var len = dv.getInt32(0, littleEndian);
		var msgId = dv.getInt32(4, littleEndian);
		var handler = this.msgHandlers[msgId];
		if (handler != undefined){
			var msgData = new ArrayBuffer(len);
			var dvMsg = new DataView(msgData);
			for (var i = 0; i < len; i++) {
				dvMsg.setInt8(i, buffer[8+i]);
			}
			handler(msgData);
		}
	},

	onLoginRet:function(bytes){
		var loginRet = login_pb.scLoginRet.deserializeBinary(bytes);
		cc.log('----login ret ' + loginRet.getResult());
	}

};

module.exports = MsgHandler;
