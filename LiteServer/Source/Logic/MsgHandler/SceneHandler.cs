
using Lite.Network;


namespace Lite
{

	class SceneHandler : IMsgHandler
	{
		public void Register()
		{
			var msgMgr = LiteFacade.GetManager<MessageManager>();
			msgMgr.RegisterHandler((ushort)PBX.MsgID.cgEnterSceneDone, OnEnterSceneOk);
			msgMgr.RegisterHandler((ushort)PBX.MsgID.cgMoveTo, OnMoveTo);
		}

		int OnEnterSceneOk(ClientSession session, byte[] bytes)
		{
			var playerMgr = LiteFacade.GetManager<PlayerManager>();
			var sceneMgr = LiteFacade.GetManager<SceneManager>();
			PlayerObject player = playerMgr.GetPlayer(session.PlayerGuid);
			Scene scene = sceneMgr.GetScene(player.SceneID);
			scene.OnPlayerEnterDone(player);
			// sync enviroment and nearby players.

			return 0;
		}

		int OnMoveTo(ClientSession session, byte[] bytes)
		{
			// notify nearby players.

			return 0;
		}


	}

}