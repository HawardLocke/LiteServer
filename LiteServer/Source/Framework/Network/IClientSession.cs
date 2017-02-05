
using System.Net;

namespace Lite.Network
{

	public interface IClientSession
	{
		long sessionGuid { get; set; }

		long playerGuid { get; set; }

		IPAddress ipAddress { get; }

		void SendPacket(int msgId, Google.Protobuf.IMessage msg);

		void SendPacket(int msgId, ProtoBuf.IExtensible msg);

		void SendPacket(int msgId, byte[] bytes);

	}

}