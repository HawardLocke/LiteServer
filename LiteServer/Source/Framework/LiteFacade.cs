using System;
using System.Collections.Generic;
using System.Text;
using Lite;
using Lite.Message;
using Lite.Service;
using Lite.Event;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Lite
{
	class LiteFacade : Singleton<LiteFacade>
	{
		private static Dictionary<Type, IManager> managerMap;

		public void Create()
		{
			managerMap = new Dictionary<Type, IManager>();
			managerMap.Add(typeof(Network.SessionManager), new Network.SessionManager());
			managerMap.Add(typeof(Event.EventManager), new Event.EventManager());
			managerMap.Add(typeof(EntityManager), new EntityManager());
			managerMap.Add(typeof(Network.MessageManager), new Network.MessageManager());
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

		// quick methods
		public static void PushEvent(InternalEvent id, IEvent evt)
		{
			//JObject jsonRoot = new JObject();
			//jsonRoot["uid"] = uid;
			//string str = JsonConvert.SerializeObject(jsonRoot);
			//GetManager<EventManager>().PushEvent(evt);
		}

	}
}
