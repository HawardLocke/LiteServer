using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;


namespace LiteServer
{
	using MsgFunc = Func<ClientSession,byte[],int>;

	class MessageHandler : Singleton<MessageHandler>
	{
		
		private Dictionary<ushort, MsgFunc> mHandlerMap = new Dictionary<ushort, MsgFunc>();

		public void RegisterHandler(ushort msgId, MsgFunc handler)
		{
			mHandlerMap.Add(msgId, handler);
		}

		public void HandlerMessage(ClientSession session, BinaryRequestInfo requestInfo)//ClientSession session, ushort msgId, byte[] bytes)
		{
			try
			{
				ByteBuffer buffer = new ByteBuffer(requestInfo.Body);
				ushort msgId = buffer.ReadShort();

				MsgFunc func = null;
				mHandlerMap.TryGetValue(msgId, out func);
				if (func != null)
				{
					byte[] bytes = buffer.ReadBytes();
					func(session, bytes);
				}
			}
			catch(Exception e)
			{
				Log.Error(typeof(MessageHandler), e.ToString());
			}
		}

	}
}
