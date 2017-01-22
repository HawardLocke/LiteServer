using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite.Network
{
	class SessionManager : IManager
	{
		private Dictionary<long, IClientSession> sessionMap = new Dictionary<long, IClientSession>();
		private HashSet<string> connectedAddress = new HashSet<string>();

		public override void Init()
		{
			
		}

		public override void Destroy()
		{

		}

		public bool AddSession(IClientSession session)
		{
			string ip = session.ipAddress.ToString();
			if (connectedAddress.Contains(ip))
			{
				Log.Error("ipaddress repeated !");
				return false;
			}

			long uid = GuidGenerator.GetLong();
			session.sessionGuid = uid;
			sessionMap.Add(session.sessionGuid, session);
			connectedAddress.Add(ip);
			Log.Info(string.Format("new session. total {0}.", sessionMap.Count));

			return true;
		}

		public void RemoveSession(IClientSession session)
		{
			long uid = session.sessionGuid;
			if (sessionMap.ContainsKey(uid))
			{
				sessionMap.Remove(uid);
				connectedAddress.Remove(session.ipAddress.ToString());
				Log.Info(string.Format("remove session. total {0}.", sessionMap.Count));
			}
		}

	}
}
