using System;
using System.Collections.Generic;
using System.Text;
using Lite;
using Lite.Message;
using Lite.Service;


namespace Lite
{
	class LiteFacade : Singleton<LiteFacade>
	{
		private static Dictionary<Type, IManager> managerMap;

		public void Create()
		{
			managerMap = new Dictionary<Type, IManager>();
			managerMap.Add(typeof(SessionManager), new SessionManager());
			managerMap.Add(typeof(EntityManager), new EntityManager());
			managerMap.Add(typeof(MessageManager), new MessageManager());
			managerMap.Add(typeof(TemplateManager), new TemplateManager());
			managerMap.Add(typeof(SceneManager), new SceneManager());
			managerMap.Add(typeof(PlayerManager), new PlayerManager());
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

		public static T GetManager<T>() where T : IManager
		{
			IManager mgr = null;
			managerMap.TryGetValue(typeof(T), out mgr);
			return mgr as T;
		}

	}
}
