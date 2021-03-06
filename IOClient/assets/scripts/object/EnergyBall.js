
const BaseObject = require('BaseObject');

var EnegyBall = cc.Class({
	name:'EnergyBall',
	extends:BaseObject,

	ctor:function(){
		this.id = 0;
		this.enegy = 0;
	},

	init:function(id, enegy){
		this._super();
		this.id = id;
		this.enegy = enegy;

		var draw = new cc.Node();
		var graph = draw.addComponent(cc.Graphics);
		graph.circle(0,0,enegy);
		//draw.drawDot(cc.p(0,0), enegy, cc.color(255,255,0,255));
		this.avatarBody.addChild(draw, 0);
	},

	setEnegy:function(enegy){
		this.enegy = enegy;
	},

	flyTo:function(x, y){
		Game.removeEnegyBall(this.id);
	}

});