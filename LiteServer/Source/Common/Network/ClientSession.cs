using System;
using System.IO;
using System.Text;
using LiteServer.Utility;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;


namespace LiteServer
{
	public class ClientSession : AppSession<ClientSession, BinaryRequestInfo>
	{
		public long uid = 0;

		protected override void OnSessionStarted()
		{
			
		}

		protected override void OnSessionClosed(CloseReason reason)
		{
			base.OnSessionClosed(reason);
		}

		protected override void HandleException(Exception e)
		{
			this.Send("Application error: {0}", e.Message);
		}

		protected override void HandleUnknownRequest(BinaryRequestInfo requestInfo)
		{
			this.Send("Unknow request");
		}

		public void SendMessage(ushort msgId, byte[] bytes)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				ms.Position = 0;
				BinaryWriter writer = new BinaryWriter(ms);
				ushort protocalId = (ushort)msgId;
				ushort msglen = (ushort)(bytes.Length + 2);
				writer.Write(msglen);
				writer.Write(protocalId);
				writer.Write(bytes);
				writer.Flush();
				if (this.Connected)
				{
					byte[] array = ms.ToArray();
					this.Send(array, 0, array.Length);
				}
			}
		}

	}
}
