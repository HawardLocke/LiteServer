using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteServer.Common;
using LiteServer.Message;

using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;


namespace LiteServer.Utility
{
	class SocketUtil
	{
		static SocketUtil socket;
		public static SocketUtil instance
		{
			get
			{
				if (socket == null)
					socket = new SocketUtil();
				return socket;
			}
		}

		public static void SendMessage(ClientSession session, PBX.MsgID msgId, byte[] message)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				ms.Position = 0;
				BinaryWriter writer = new BinaryWriter(ms);
				ushort protocalId = (ushort)msgId;
				ushort msglen = (ushort)(message.Length + 2);
				writer.Write(msglen);
				writer.Write(protocalId);
				writer.Write(message);
				writer.Flush();
				if (session != null && session.Connected)
				{
					byte[] payload = ms.ToArray();
					session.Send(payload, 0, payload.Length);
				}
				else
				{
					Console.WriteLine("client.connected----->>false");
				}
			}
		}

		public void OnSessionConnected(ClientSession session)
		{
			Console.WriteLine("OnSessionConnected--->>>" + session.RemoteEndPoint.Address);
		}

		public void OnSessionClosed(ClientSession session, CloseReason reason)
		{
			Console.WriteLine("OnSessionClosed--->>>" + session.RemoteEndPoint.Address + ", reason " + reason.ToString());
		}

		public void OnRequestReceived(ClientSession session, BinaryRequestInfo requestInfo)
		{
			ByteBuffer buffer = new ByteBuffer(requestInfo.Body);
			int commandId = buffer.ReadShort();
			PBX.MsgID msgId = (PBX.MsgID)commandId;
			Console.WriteLine("OnRequestReceived : " + msgId);

			byte[] bytes = buffer.ReadBytes();

			Login loginMsg = Login.Parser.ParseFrom(bytes);
			Console.WriteLine(loginMsg.Name);
			Console.WriteLine(loginMsg.Password);

			Login loginRet = new Login
			{
				Name = "Locke007back",
				Password = "666"
			};

			byte[] bytesRet = Google.Protobuf.MessageExtensions.ToByteArray(loginRet);

			SendMessage(session, PBX.MsgID.Login, bytesRet);

			//Protocal c = (Protocal)commandId;
			//string className = "LiteServer.Message." + c;
			//Console.WriteLine("OnRequestReceived--->>>" + className);

			/*Type t = Type.GetType(className);
			IMessage obj = (IMessage)Activator.CreateInstance(t);
			if (obj != null)
				obj.OnMessage(session, buffer);
			obj = null;
			t = null;*/
		}
	}
}
