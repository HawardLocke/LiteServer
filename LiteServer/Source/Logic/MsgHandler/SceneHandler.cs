
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
			msgMgr.RegisterHandler((ushort)MsgID.cgEnterSceneDone, OnEnterSceneDone);
			msgMgr.RegisterHandler((ushort)MsgID.cgMoveTo, OnMoveTo);
		}

		int OnEnterSceneDone(IClientSession session, byte[] bytes)
		{
			return 0;
		}

		int OnMoveTo(IClientSession session, byte[] bytes)
		{
			return 0;
		}

		int OnMoveTowards(IClientSession session, byte[] bytes)
		{
			long guid = session.playerGuid;
			float x = 0;
			float y = 0;
			Vector2 dir = new Vector2(x, y);

			EntityManager entMgr = AppFacade.GetManager<EntityManager>();
			Entity ent = entMgr.FindPlayerEntity(guid);

			ent.rigidBody.force = dir * 1;

			return 0;
		}

	}

}