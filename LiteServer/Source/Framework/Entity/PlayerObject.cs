using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lite
{
	public class PlayerObject : PawnObject
	{
		private long mPlayerID = 0;
		private long mSessionID = 0;

		public override void OnSpawn()
		{
			base.OnSpawn();
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
		}

		public void SendPacket(ushort msgId, byte[] bytes)
		{
			ClientSession session = LiteFacade.GetManager<SessionManager>().Get(mSessionID);
			if (session != null)
			{
				session.SendPacket(msgId, bytes);
			}
		}

	}
}
