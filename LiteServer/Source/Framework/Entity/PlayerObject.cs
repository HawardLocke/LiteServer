using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lite
{
	public class PlayerObject : PawnObject
	{
		private long mPlayerGuid = 0;
		public long PlayerGuid
		{
			get { return mPlayerGuid; }
		}

		private long mSessionID = 0;
		public long SessionID
		{
			get { return mSessionID; }
		}

		public PlayerObject(int entityId, long playerGuid, long sessionId):
			base(entityId)
		{
			mPlayerGuid = playerGuid;
			mSessionID = sessionId;
		}

		public override void OnCreate()
		{
			base.OnCreate();
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
		}

		public void SendPacket(PBX.MsgID msgId, Google.Protobuf.IMessage msg)
		{
			this.SendPacket((ushort)msgId, Google.Protobuf.MessageExtensions.ToByteArray(msg));
		}

		private void SendPacket(ushort msgId, byte[] bytes)
		{
			ClientSession session = LiteFacade.GetManager<SessionManager>().Get(mSessionID);
			if (session != null)
			{
				session.SendPacket(msgId, bytes);
			}
			else
			{
				Log.Error("PlayerObject.SendPacket: session is null.");
			}
		}

	}
}
