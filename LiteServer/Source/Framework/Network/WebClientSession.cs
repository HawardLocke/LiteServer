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

		public void SendPacket(ushort msgId, ProtoBuf.IExtensible msg)
		{
			byte[] data = null;
			using (var stream = new MemoryStream())
			{
				ProtoBuf.Serializer.Serialize(stream, msg);
				stream.Flush();
				data = stream.ToArray();
			}
			this.SendPacket((ushort)msgId, data);
		}

		public void SendPacket(ushort msgId, byte[] bytes)
		{
			ByteBuffer buffer = new ByteBuffer();
			buffer.WriteBytes(bytes);
			byte[] message = buffer.ToBytes();

			using (MemoryStream ms = new MemoryStream())
			{
				ms.Position = 0;
				BinaryWriter writer = new BinaryWriter(ms);
				ushort msglen = (ushort)(message.Length + sizeof(ushort));
				writer.Write(msglen);
				writer.Write(msgId);
				writer.Write(message);
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