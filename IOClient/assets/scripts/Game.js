
const MsgHandler = require('MsgHandler');

var Game = {

	enegyBallList:{},

	Init:function(){
		MsgHandler.Init();
	},

	AddEnegyBall:function(id, enegy, x, y){
		if(this.enegyBallList[id] == undefined){
			var inst = new EnegyBall();
			inst.Init(id, enegy);
			this.enegyBallList[id] = inst;
			inst.setPosition(x, y);
			inst.onCreate();
			return inst;
		}
		else{
			inst = this.enegyBallList[id];
			inst.setPosition(x, y);
			inst.setEnegy(enegy);
		}
	},

};


module.exports = Game;
