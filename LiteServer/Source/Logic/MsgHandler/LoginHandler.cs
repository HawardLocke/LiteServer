
using System;
using System.IO;
using ProtoBuf;
using Lite.Protocol;
using Lite.Network;


namespace Lite
{
	class LoginHandler : IMsgHandler
	{
		public void Register()
		{
			var msgMgr = LiteFacade.GetManager<MessageManager>();
			msgMgr.RegisterHandler((ushort)PBX.MsgID.cgLogin, OncgLogin);
			msgMgr.RegisterHandler((ushort)PBX.MsgID.cgEnterGame, OncgEnterGame);
		}

		int OncgLogin(IClientSession session, byte[] bytes)
		{
			cgLogin loginMsg = ProtoUtil.ParseFrom<cgLogin>(bytes);
			//cgLogin loginMsg = cgLogin.Parser.ParseFrom(bytes);
			Log.Info(string.Format("recv Login,{0},{1}.", loginMsg.account, loginMsg.password));

			gcLoginRet loginRet = new gcLoginRet
			{
				result = 0
			};
			session.SendPacket((ushort)PBX.MsgID.gcLoginRet, loginRet);

			return 0;
		}

		int OncgEnterGame(IClientSession session, byte[] bytes)
		{
			cgEnterGame recvMsg = ProtoUtil.ParseFrom<cgEnterGame>(bytes); //cgEnterGame.Parser.ParseFrom(bytes);
			Log.Info(string.Format("recv EnterGame,{0}.", recvMsg.roleIndex));

			gcEnterGameRet enterRet = new gcEnterGameRet();
			enterRet.result = 0;
			session.SendPacket((ushort)PBX.MsgID.gcEnterGameRet, enterRet);

			// new player
// 			var playerMgr = LiteFacade.GetManager<PlayerManager>();
// 			long playerGuid = GuidGenerator.GetLong();
// 			session.PlayerGuid = playerGuid;
// 			int entityId = LiteFacade.GetManager<EntityManager>().GenEntityID();
// 			PlayerObject player = new PlayerObject(entityId, playerGuid, session.SessionGuid);
// 			playerMgr.AddPlayer(player);
// 
// 			// test : enter default scene
// 			var sceneMgr = LiteFacade.GetManager<SceneManager>();
// 			var targetScene = sceneMgr.MainScene;
// 			targetScene.AddPlayer(playerGuid, player);
// 
// 			gcEnterScene enterSceneMsg = new gcEnterScene();
// 			enterSceneMsg.sceneId = targetScene.SceneID;
// 			player.SendPacket((ushort)PBX.MsgID.gcEnterScene, enterSceneMsg);

			return 0;
		}

	}
}