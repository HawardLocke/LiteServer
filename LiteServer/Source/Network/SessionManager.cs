using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteServer
{
	class SessionManager : Singleton<SessionManager>
	{
		private Dictionary<long, ClientSession> sessionMap = new Dictionary<long,ClientSession>();

		public void Add(long uid, ClientSession session)
		{
			session.uid = uid;
			sessionMap.Add(uid, session);
		}

		public void Quit(long uid)
		{
			sessionMap.Remove(uid);
		}
		public bool Exist(long uid)
		{
			return sessionMap.ContainsKey(uid);
		}

		public ClientSession Get(long uid)
		{
			Dictionary<long, ClientSession> users = sessionMap;
			foreach (KeyValuePair<long, ClientSession> u in sessionMap)
			{
				if (u.Key != uid) continue;
				return u.Value;
			}
			return null;
		}

		public void Remove(long uid)
		{
			sessionMap.Remove(uid);
		}

	}
}
