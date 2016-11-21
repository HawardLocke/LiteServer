using System;

namespace Lite
{
	public interface IMessage
	{
		void OnMessage(Network.ClientSession session, ByteBuffer buffer);
	}
}
