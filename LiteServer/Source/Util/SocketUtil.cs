using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteServer;
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

		/*public void OnRequestReceived(ClientSession session, BinaryRequestInfo requestInfo)
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
		}*/
	}
}
