using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite
{
	class SessionManager : Singleton<SessionManager>
	{
		private Dictionary<long, ClientSession> sessionMap = new Dictionary<long,ClientSession>();



		public void Add(ClientSession session)
		{
			if (sessionMap.ContainsValue(session))
			{
				return;
			}
			long uid = GuidGenerator.GetLong();
			session.uid = uid;
			sessionMap.Add(uid, session);
			Console.WriteLine("add session.. total " + sessionMap.Count);
		}

		public void Remove(long uid)
		{
			sessionMap.Remove(uid);
			Console.WriteLine("remove session.. total " + sessionMap.Count);
		}

		public ClientSession Get(long uid)
		{
			ClientSession session = null;
			sessionMap.TryGetValue(uid, out session);
			return session;
		}

	}
}
