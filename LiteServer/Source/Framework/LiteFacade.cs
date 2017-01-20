using System;
using System.Collections.Generic;
using Entitas;
using Lite.Event;



namespace Lite
{
	class LiteFacade : Singleton<LiteFacade>
	{
		private static Dictionary<Type, IManager> managerMap;

		private Systems systems;

		public void Create()
		{
			managerMap = new Dictionary<Type, IManager>();
			managerMap.Add(typeof(Network.SessionManager), new Network.SessionManager());
			managerMap.Add(typeof(Event.EventManager), new Event.EventManager());
			managerMap.Add(typeof(Network.MessageManager), new Network.MessageManager());
			managerMap.Add(typeof(TemplateManager), new TemplateManager());
			//managerMap.Add(typeof(SceneManager), new SceneManager());
			//managerMap.Add(typeof(PlayerManager), new PlayerManager());

		/*	 var pools = Pools.sharedInstance;
        pools.SetAllPools();
        pools.AddEntityIndices();
			systems = */
		}
		
		public void Init()
		{
			foreach(var mgr in managerMap.Values)
			{
				mgr.Init();
			}
		}

		public void Destroy()
		{
		}

		public void Tick()
		{
			
		}

		public static T GetManager<T>() where T : IManager
		{
			IManager mgr = null;
			managerMap.TryGetValue(typeof(T), out mgr);
			return mgr as T;
		}

	}
}
