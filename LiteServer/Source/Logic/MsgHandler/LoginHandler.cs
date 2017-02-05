
using System;
using System.IO;
using ProtoBuf;
using Protocol;
using Lite.Network;


namespace Lite
{
	class LoginHandler : IMsgHandler
	{
		public void Register()
		{
			var msgMgr = LiteFacade.GetManager<MessageManager>();
			msgMgr.RegisterHandler((int)MsgID.csLogin, OncsLogin);
			msgMgr.RegisterHandler((int)MsgID.csEnterGame, OncsEnterGame);
		}

		int OncsLogin(IClientSession session, byte[] bytes)
		{
			csLogin loginMsg = csLogin.Parser.ParseFrom(bytes);
			//csLogin loginMsg = ProtoUtil.ParseFrom<csLogin>(bytes);

			/*csLogin loginMsg = new csLogin
			{
				account = "Locke",
				password = "******"
			};

			byte[] data = null;
			using (var stream = new MemoryStream())
			{
				ProtoBuf.Serializer.Serialize(stream, loginMsg);
				stream.Flush();
				data = stream.ToArray();
			}*/

			Log.Info(string.Format("recv Login,{0},{1}.", loginMsg.Account, loginMsg.Password));

			scLoginRet loginRet = new scLoginRet
			{
				Result = 0
			};
			session.SendPacket((int)MsgID.scLoginRet, loginRet);

			return 0;
		}

		int OncsEnterGame(IClientSession session, byte[] bytes)
		{
			csEnterGame recvMsg = csEnterGame.Parser.ParseFrom(bytes);
			Log.Info(string.Format("recv EnterGame,{0}.", recvMsg.RoleIndex));

			scEnterGameRet enterRet = new scEnterGameRet();
			enterRet.Result = 0;
			session.SendPacket((int)MsgID.scEnterGameRet, enterRet);

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
// 			scEnterScene enterSceneMsg = new scEnterScene();
// 			enterSceneMsg.sceneId = targetScene.SceneID;
// 			player.SendPacket((ushort)MsgID.scEnterScene, enterSceneMsg);

			return 0;
		}

	}
}