
using Protocol;
using Lite.Network;

using Entitas;


namespace Lite
{

	class SceneHandler : IMsgHandler
	{
		public void Register()
		{
			var msgMgr = AppFacade.GetManager<MessageManager>();
			msgMgr.RegisterHandler((ushort)MsgID.csJoin, OnJoin);
			msgMgr.RegisterHandler((ushort)MsgID.csMoveTowards, OnMoveTowards);
			msgMgr.RegisterHandler((ushort)MsgID.csPing, OnPing);
			msgMgr.RegisterHandler((ushort)MsgID.csCollectEnergyBall, OnCollectEnergyBall);
			msgMgr.RegisterHandler((ushort)MsgID.csShoot, OnShoot);
		}

		int OnJoin(IClientSession session, byte[] bytes)
		{
			//csJoin request = csJoin.Parser.ParseFrom(bytes);

			// send world info
			scSceneInfo sceneInfo = new scSceneInfo();
			sceneInfo.Width = 1000;
			sceneInfo.Height = 1000;
			session.SendPacket((int)MsgID.scSceneInfo, sceneInfo);

			// send energy balls
			var entMgr = AppFacade.GetManager<EntityManager>();
			//entMgr.FindEntity
			var ballMatcher = Matcher.AllOf(GameObjectsMatcher.EnergyBall);
			var ballGroup = Pools.sharedInstance.gameObjects.GetGroup(ballMatcher);
			foreach (var e in ballGroup.GetEntities())
			{
				scEnergyBallInfo ballInfo = new scEnergyBallInfo();
				ballInfo.BallId = e.creationIndex;
				ballInfo.Energy = e.energy.value;
				ballInfo.X = e.transform.position.x;
				ballInfo.Y = e.transform.position.y;
				session.SendPacket((int)MsgID.scEnergyBallInfo, ballInfo);
			}

			// self player
			long newGuid = GuidGenerator.GetLong();
			session.playerGuid = newGuid;

			
			var ent = entMgr.CreatePlayer(newGuid, "ShenMe?", Vector2.zero, 10, Vector2.zero, 15, 3, 5);


			scPlayerJoined joined = new scPlayerJoined();

			var info = new scPlayerInfo();
			info.Guid = ent.playerInfo.playerGuid;
			info.Name = ent.playerInfo.playerName;
			info.Energy = ent.energy.value;
			var move = new scMovementInfo();
			move.X = ent.transform.position.x;
			move.Y = ent.transform.position.y;
			move.Vx = ent.rigidBody.velocity.x;
			move.Vy = ent.rigidBody.velocity.y;
			move.Fx = ent.rigidBody.force.x;
			move.Fy = ent.rigidBody.force.y;
			info.Movement = move;

			joined.PlayerInfo = info;

			session.SendPacket((int)MsgID.scPlayerJoined, joined);

			return 0;
		}

		int OnMoveTowards(IClientSession session, byte[] bytes)
		{
			csMoveTowards request = csMoveTowards.Parser.ParseFrom(bytes);

			long guid = session.playerGuid;
			float x = request.X;
			float y = request.Y;
			Vector2 dir = new Vector2(x, y);

			EntityManager entMgr = AppFacade.GetManager<EntityManager>();
			Entity ent = entMgr.FindPlayerEntity(guid);

			ent.rigidBody.force = dir * 1;

			return 0;
		}

		int OnPing(IClientSession session, byte[] bytes)
		{
			csPing request = csPing.Parser.ParseFrom(bytes);
			long clientTime = request.ClientTime;

			return 0;
		}

		int OnCollectEnergyBall(IClientSession session, byte[] bytes)
		{
			csCollectEnergyBall request = csCollectEnergyBall.Parser.ParseFrom(bytes);
			int ballId = request.BallId;

			return 0;
		}

		int OnShoot(IClientSession session, byte[] bytes)
		{
			csShoot request = csShoot.Parser.ParseFrom(bytes);
			float dirx = request.X;
			float diry = request.Y;

			return 0;
		}

	}

}