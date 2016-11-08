using System;

namespace LiteServer
{
	public interface IMessage
	{
		void OnMessage(ClientSession session, ByteBuffer buffer);
	}
}
