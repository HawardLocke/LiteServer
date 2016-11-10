using System;

namespace Lite
{
	public interface IMessage
	{
		void OnMessage(ClientSession session, ByteBuffer buffer);
	}
}
