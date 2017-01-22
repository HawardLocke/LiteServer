
namespace Lite.Network
{

	public interface IClientSession
	{
		long sessionGuid { get; set; }
		long playerGuid { get; set; }

		void SendPacket(ushort msgId, ProtoBuf.IExtensible msg);

		void SendPacket(ushort msgId, byte[] bytes);

	}

}