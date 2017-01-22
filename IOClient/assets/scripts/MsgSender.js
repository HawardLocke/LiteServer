
const Network = require('Network');
const Protocol = require('Protocol');

var MsgType = {
	// c->s
	csLogin:2001,
	scLoginRet:2002,

	csJoin:1002,
	csMove:1003,
	csPing:1004,
	csEatEnegyBall: 1005,
	csShoot:1006,
	csHitPlayer:1007,
	// s->c
	scError:2000,
	scNewPlayer:2001,
	scJoined:2002,
	scWorldInfo:2003,
	scDeletePlayer:2004,
	scMove:2005,
	scPlayerInfo:2006,
	scPing:2007,
	scEnegyInfo:2008,
	scEatEnegyBall: 2009,
	scEnegyChange:2010,
	scShoot:2011,
	scBulletInfo:2012,
	scHitPlayer:2013
};

var MsgSender = {

    name:null,
	pswd:null,

	SendLogin:function(name, pswd){
        var login = new Protocol.IOGame.csLogin();
        login.account = name;
        login.password = pswd;
		Network.send(MsgType.csLogin, login);
	},

	join:function(){
		Network.send([MsgType.csJoin]);
	},

	move:function(degree,dirx, diry, posx, posy, vx, vy){
		var timeStamp = Game.calServerTimeNow();
		//cc.log('st ' + timeStamp);
		Network.send([MsgType.csMove,timeStamp,degree,dirx,diry,posx,posy,vx,vy]);
	},

	ping:function(pingCount, clientTime){
		Network.send([MsgType.csPing, pingCount, clientTime])
	},

	eatEnegyBall:function(ballId){
		Network.send([MsgType.csEatEnegyBall, ballId])
	},

	shoot:function(x, y, dirx, diry){
		var timeStamp = Game.calServerTimeNow();
		Network.send([MsgType.csShoot, timeStamp, x, y, dirx, diry])
	},

	hitPlayer:function(bulletId, playerId){
		Network.send([MsgType.csHitPlayer, bulletId, playerId])
	}

	
	
};

module.exports = MsgSender;