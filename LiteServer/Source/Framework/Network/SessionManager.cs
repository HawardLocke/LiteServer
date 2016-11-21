using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Network
{
	class SessionManager : IManager
	{
		private Dictionary<long, ClientSession> sessionMap;

		public override void Init()
		{
			sessionMap = new Dictionary<long, ClientSession>();
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
			session.SessionGuid = uid;
			sessionMap.Add(uid, session);
			Log.Info(string.Format("new session. total {0}.", sessionMap.Count));
		}

		public void RemoveSession(long uid)
		{
			sessionMap.Remove(uid);
			Log.Info(string.Format("remove session. total {0}.", sessionMap.Count));
		}

		public ClientSession Get(long uid)
		{
			ClientSession session = null;
			sessionMap.TryGetValue(uid, out session);
			return session;
		}

	}
}
