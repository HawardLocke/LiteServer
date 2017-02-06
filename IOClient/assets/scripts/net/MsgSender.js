
const Network = require('Network');
//const Protocol = require('Protocol');

const MsgID = require('MsgID');
const login_pb = require('login_pb');
const scene_pb = require('scene_pb');
const chat_pb = require('chat_pb');


var MsgSender = {

    name:null,
	pswd:null,

	_send:function(msgId, msg){
		Network.send(msgId, msg.serializeBinary());
	},

	SendLogin:function(name, pswd){
        var login = new login_pb.csLogin();//Protocol.IOGame.csLogin();
        login.setAccount(name);
        login.setPassword(pswd);
		this._send(MsgID.csLogin, login);
	},

	SendJoin:function(){
		var msg = new scene_pb.csJoin();
		this._send(MsgID.csJoin, msg);
	},

	move:function(degree,dirx, diry, posx, posy, vx, vy){
		var timeStamp = Game.calServerTimeNow();
		//cc.log('st ' + timeStamp);
		Network.send([MsgID.cgMove,timeStamp,degree,dirx,diry,posx,posy,vx,vy]);
	},

	ping:function(pingCount, clientTime){
		Network.send([MsgID.cgPing, pingCount, clientTime])
	},

	eatEnegyBall:function(ballId){
		Network.send([MsgID.cgEatEnegyBall, ballId])
	},

	shoot:function(x, y, dirx, diry){
		var timeStamp = Game.calServerTimeNow();
		Network.send([MsgID.cgShoot, timeStamp, x, y, dirx, diry])
	},

	hitPlayer:function(bulletId, playerId){
		Network.send([MsgID.cgHitPlayer, bulletId, playerId])
	}

	
	
};

module.exports = MsgSender;