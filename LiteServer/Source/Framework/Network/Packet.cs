

namespace Lite.Network
{
	public sealed class Packet
	{
		public ushort length;
		public ushort msgId;
		//public int stamp;
		public byte[] data;
	}

}