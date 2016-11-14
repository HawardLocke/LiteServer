

namespace Lite
{

	class SceneHandler : IMsgHandler
	{
		public void Register()
		{
			//LiteFacade.GetManager<MessageManager>().RegisterHandler((ushort)PBX.MsgID.EnterScene, OnLoginRequest);
			//LiteFacade.GetManager<MessageManager>().RegisterHandler((ushort)PBX.MsgID.Move, OnLoginRequest);
			//LiteFacade.GetManager<MessageManager>().RegisterHandler((ushort)PBX.MsgID.Attack, OnLoginRequest);
		}

		int OnEnterSceneOk(ClientSession session, byte[] bytes)
		{
			// notify nearby players.

			return 0;
		}


	}

}