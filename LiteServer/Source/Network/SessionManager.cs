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

		private long genUid = 1991;

		public void Add(ClientSession session)
		{
			if (sessionMap.ContainsValue(session))
			{
				return;
			}
			long uid = genUid++;
			session.uid = uid;
			sessionMap.Add(uid, session);
		}

		public void Remove(long uid)
		{
			sessionMap.Remove(uid);
		}

		public ClientSession Get(long uid)
		{
			ClientSession session = null;
			sessionMap.TryGetValue(uid, out session);
			return session;
		}

	}
}
