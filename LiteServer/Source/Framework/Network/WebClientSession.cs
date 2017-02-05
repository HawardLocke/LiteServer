using System;
using System.IO;
using System.Text;
using Lite.Utility;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.WebSocket;


namespace Lite.Network
{
	public class WebClientSession : WebSocketSession<WebClientSession>, IClientSession
	{
		public long sessionGuid { get; set; }

		public long playerGuid { get; set; }

		public System.Net.IPAddress ipAddress { get { return RemoteEndPoint.Address; } }


		protected override void OnSessionStarted()
		{
			
		}

		protected override void OnSessionClosed(CloseReason reason)
		{
			base.OnSessionClosed(reason);
		}

		protected override void HandleException(Exception e)
		{
			//this.Send("Application error: {0}", e.Message);
		}

		public void SendPacket(int msgId, Google.Protobuf.IMessage msg)
		{
			byte[] data = Google.Protobuf.MessageExtensions.ToByteArray(msg);
			this.SendPacket(msgId, data);
		}

		public void SendPacket(int msgId, ProtoBuf.IExtensible msg)
		{
			byte[] data = null;
			using (var stream = new MemoryStream())
			{
				ProtoBuf.Serializer.Serialize(stream, msg);
				stream.Flush();
				data = stream.ToArray();
			}
			this.SendPacket(msgId, data);
		}

		public void SendPacket(int msgId, byte[] bytes)
		{
			if (this.Connected)
			{
				/*ByteBuffer buffer = new ByteBuffer();
				buffer.WriteBytes(bytes);
				byte[] message = buffer.ToBytes();*/

				using (MemoryStream ms = new MemoryStream())
				{
					ms.Position = 0;
					BinaryWriter writer = new BinaryWriter(ms);
					int msglen = bytes.Length/* + sizeof(int)*/;
					writer.Write(msglen);
					writer.Write(msgId);
					writer.Write(bytes);
					writer.Flush();

					byte[] array = ms.ToArray();
					this.Send(array, 0, array.Length);
				}
			}
		}

	}
}