using System;
using System.Collections.Generic;


namespace Lite
{
	class AppFacade : Singleton<AppFacade>
	{
		private static Dictionary<Type, IManager> managerMap = new Dictionary<Type, IManager>();
		private static List<IManager> managerList = new List<IManager>();
		private static List<IManager> rapidManagerList = new List<IManager>();
		
		public void Init()
		{
			_addManager(typeof(TemplateManager), new TemplateManager());
			_addManager(typeof(Network.SessionManager), new Network.SessionManager());
			_addManager(typeof(Event.EventManager), new Event.EventManager());
			_addManager(typeof(Network.MessageManager), new Network.MessageManager());
			
			_addManager(typeof(ECSManager), new ECSManager(), true);
			_addManager(typeof(EntityManager), new EntityManager());

			_addManager(typeof(SceneManager), new SceneManager());

			TemplateRegister.RegisterALL();

			foreach (var mgr in managerMap)
				mgr.Value.Init();

			GameTimer.Start();
		}

		public void Destroy()
		{
			foreach (var mgr in managerMap)
				mgr.Value.Destroy();
		}

		public void Tick()
		{
			foreach (var mgr in managerList)
				mgr.Update();
		}

		public void RapidTick()
		{
			GameTimer.Tick();

			foreach (var mgr in rapidManagerList)
				mgr.Update();
		}

		public static T GetManager<T>() where T : IManager
		{
			IManager mgr = null;
			managerMap.TryGetValue(typeof(T), out mgr);
			return mgr as T;
		}

		private void _addManager(Type tp, IManager mgr, bool rapid = false)
		{
			managerMap.Add(tp, mgr);
			if (rapid)
				rapidManagerList.Add(mgr);
			else
				managerList.Add(mgr);
		}

	}
}
