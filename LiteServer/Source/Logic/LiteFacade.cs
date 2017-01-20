using System;
using System.Collections.Generic;


namespace Lite
{
	class LiteFacade : Singleton<LiteFacade>
	{
		private static Dictionary<Type, IManager> managerMap = new Dictionary<Type, IManager>();
		private static List<IManager> managerList = new List<IManager>();

		
		public void Init()
		{
			_addManager(typeof(TemplateManager), new TemplateManager());
			_addManager(typeof(Network.SessionManager), new Network.SessionManager());
			_addManager(typeof(Event.EventManager), new Event.EventManager());
			_addManager(typeof(Network.MessageManager), new Network.MessageManager());
			_addManager(typeof(SceneManager), new SceneManager());
			_addManager(typeof(EcsManager), new EcsManager());

			TemplateRegister.RegisterALL();

			foreach (var mgr in managerList)
				mgr.Init();
			
		}

		public void Destroy()
		{
			foreach (var mgr in managerList)
				mgr.Destroy();
		}

		public void Tick()
		{
			foreach (var mgr in managerList)
				mgr.Update();
		}

		public static T GetManager<T>() where T : IManager
		{
			IManager mgr = null;
			managerMap.TryGetValue(typeof(T), out mgr);
			return mgr as T;
		}

		private void _addManager(Type tp, IManager mgr)
		{
			managerMap.Add(tp, mgr);
			managerList.Add(mgr);
		}

	}
}
