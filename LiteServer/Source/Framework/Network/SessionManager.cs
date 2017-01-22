using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Network
{
	class SessionManager : IManager
	{
		private Dictionary<long, ClientSession> sessionMap = new Dictionary<long, ClientSession>();
		private Dictionary<long, WebClientSession> wsSessionMap = new Dictionary<long, WebClientSession>();

		public override void Init()
		{
			
		}

		public override void Destroy()
		{

		}

		public void AddSession(ClientSession session)
		{
			if (sessionMap.ContainsValue(session))
			{
				return;
			}
			long uid = GuidGenerator.GetLong();
			session.sessionGuid = uid;
			sessionMap.Add(uid, session);
			Log.Info(string.Format("new session. total {0}.", sessionMap.Count));
		}

		public void AddSession(WebClientSession session)
		{
			if (wsSessionMap.ContainsValue(session))
			{
				return;
			}
			long uid = GuidGenerator.GetLong();
			session.sessionGuid = uid;
			wsSessionMap.Add(uid, session);
			Log.Info(string.Format("new session. total {0}.", wsSessionMap.Count));
		}

		public void RemoveSession(long uid)
		{
			if (sessionMap.ContainsKey(uid))
			{
				sessionMap.Remove(uid);
				Log.Info(string.Format("remove session. total {0}.", sessionMap.Count));
			}
			else if (wsSessionMap.ContainsKey(uid))
			{
				wsSessionMap.Remove(uid);
				Log.Info(string.Format("remove session. total {0}.", wsSessionMap.Count));
			}
		}

		/*public ClientSession Get(long uid)
		{
			ClientSession session = null;
			sessionMap.TryGetValue(uid, out session);
			return session;
		}*/

	}
}
