
using System;
using Google.Protobuf;


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

		int OncgLogin(ClientSession session, byte[] bytes)
		{
			cgLogin loginMsg = cgLogin.Parser.ParseFrom(bytes);
			Log.Info(string.Format("recv Login,{0},{1}.", loginMsg.Account, loginMsg.Password));

			gcLoginRet loginRet = new gcLoginRet
			{
				Result = 0
			};
			session.SendPacket(PBX.MsgID.gcLoginRet, loginRet);

			return 0;
		}

		int OncgEnterGame(ClientSession session, byte[] bytes)
		{
			cgEnterGame recvMsg = cgEnterGame.Parser.ParseFrom(bytes);
			Log.Info(string.Format("recv EnterGame,{0}.", recvMsg.RoleIndex));

			gcEnterGameRet enterRet = new gcEnterGameRet();
			enterRet.Result = 0;
			session.SendPacket(PBX.MsgID.gcEnterGameRet, enterRet);

			// new player
			var playerMgr = LiteFacade.GetManager<PlayerManager>();
			long playerGuid = GuidGenerator.GetLong();
			session.PlayerGuid = playerGuid;
			int entityId = LiteFacade.GetManager<EntityManager>().GenEntityID();
			PlayerObject player = new PlayerObject(entityId, playerGuid, session.SessionGuid);
			playerMgr.AddPlayer(player);

			// test : enter default scene
			var sceneMgr = LiteFacade.GetManager<SceneManager>();
			var targetScene = sceneMgr.MainScene;
			targetScene.AddPlayer(playerGuid, player);
			gcEnterScene enterSceneMsg = new gcEnterScene();
			enterSceneMsg.SceneId = sceneMgr.MainScene.SceneID;
			player.SendPacket(PBX.MsgID.gcEnterScene, enterSceneMsg);

			return 0;
		}

	}
}