
const Network = require('Network');

const MsgID = require('./protobuf/MsgID');
var login_pb = require('./protobuf/login_pb');
var scene_pb = require('./protobuf/scene_pb');
var chat_pb = require('./protobuf/chat_pb');

var MsgHandler = {

	msgHandlers:{},

	Init:function(){
		this.registHandler(MsgID.scLoginRet, this.onLoginRet);

		this.registHandler(MsgID.scPlayerJoined, this.onPlayerJoined);
		this.registHandler(MsgID.scPlayerQuit, this.onPlayerQuit);
		this.registHandler(MsgID.scPlayerMove, this.onPlayerMove);

		this.registHandler(MsgID.scPing, this.onPing);
		this.registHandler(MsgID.scCollectEnergyBall, this.onCollectEnergyBall);
		this.registHandler(MsgID.scEnergyChange, this.onEnergyChanged);
		this.registHandler(MsgID.scShoot, this.onPlayerShoot);
		this.registHandler(MsgID.scHitPlayer, this.onHitPlayer);

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
		// change scene if succeed.
		//cc.director.loadScene('MyScene', onSceneLaunched);
	},

	onPlayerJoined:function(bytes){
		var recvdMsg = scene_pb.scPlayerJoined.deserializeBinary(bytes);
	},

	onPlayerQuit:function(bytes){
		var recvdMsg = scene_pb.scPlayerQuit.deserializeBinary(bytes);
	},

	onPlayerMove:function(bytes){
		var recvdMsg = scene_pb.scPlayerMove.deserializeBinary(bytes);
	},

	onPing:function(bytes){
		var recvdMsg = scene_pb.scPing.deserializeBinary(bytes);
	},

	onCollectEnergyBall:function(bytes){
		var recvdMsg = scene_pb.scCollectEnergyBall.deserializeBinary(bytes);
	},

	onEnergyChanged:function(bytes){
		var recvdMsg = scene_pb.scEnergyChange.deserializeBinary(bytes);
	},

	onPlayerShoot:function(bytes){
		var recvdMsg = scene_pb.scShoot.deserializeBinary(bytes);
	},

	onHitPlayer:function(bytes){
		var recvdMsg = scene_pb.scHitPlayer.deserializeBinary(bytes);
	},

};

module.exports = MsgHandler;
