﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;


namespace Lite.Network
{
	using MsgHandler = Func<IClientSession,byte[],int>;

	class MessageManager : IManager
	{

		private Dictionary<int, MsgHandler> mHandlerMap = new Dictionary<int, MsgHandler>();

		public void RegisterHandler(int msgId, MsgHandler handler)
		{
			mHandlerMap.Add(msgId, handler);
		}

		public void HandlerMessage(ClientSession session, BinaryRequestInfo requestInfo)
		{
			try
			{
				ByteBuffer buffer = new ByteBuffer(requestInfo.Body);
				ushort msgId = buffer.ReadShort();

				MsgHandler func = null;
				mHandlerMap.TryGetValue(msgId, out func);
				if (func != null)
				{
					byte[] bytes = buffer.ReadBytes();
					func(session, bytes);
				}
			}
			catch(Exception e)
			{
				Log.Error(e.ToString());
			}
		}

		public void HandlerMessage(WebClientSession session, byte[] requestInfo)
		{
			try
			{
				ByteBuffer buffer = new ByteBuffer(requestInfo);
				int msgId = buffer.ReadInt();

				MsgHandler func = null;
				mHandlerMap.TryGetValue(msgId, out func);
				if (func != null)
				{
					byte[] bytes = buffer.ReadBytes();
					func(session, bytes);
				}
			}
			catch (Exception e)
			{
				Log.Error(e.ToString());
			}
		}

	}
}
