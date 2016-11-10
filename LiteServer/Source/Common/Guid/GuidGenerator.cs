
using System;


namespace Lite
{
	public sealed class GuidGenerator
	{
		public static long GetLong()
		{
			byte[] buffer = Guid.NewGuid().ToByteArray();
			return BitConverter.ToInt64(buffer, 0);
		}

		private static string GetString()
		{
			System.Guid guid = new Guid();
			guid = Guid.NewGuid();
			return guid.ToString();
		}

	}

}
