
using System;
using System.IO;
using System.Text;
using ProtoBuf;


namespace Lite.Protocol
{
	public class ProtoUtil
	{
		public static T ParseFrom<T>(byte[] data)
		{
			using (var stream = new MemoryStream(data))
			{
				return (T)Serializer.Deserialize<T>(stream);
			}
		}

		public static byte[] ToByteArray<T>(T obj)
		{
			using (var stream = new MemoryStream())
			{
				Serializer.Serialize(stream, obj);
				stream.Flush();
				return stream.ToArray();
			}
		}
	}
}
