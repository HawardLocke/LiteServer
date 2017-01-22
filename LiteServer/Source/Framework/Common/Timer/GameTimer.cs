
using System;

namespace Lite
{

	public class GameTimer
	{
		private static long startTick = 0;
		//private static long lastTick = 0;

		public static void Start()
		{
			//startTick = DateTime.Now.Ticks;
		}

		// in milliseconds
		public static long realtimeSinceStartup
		{
			get
			{
				return (DateTime.Now.Ticks - startTick) / 10000;
			}
		}

		// in milliseconds
		public static long tickTime
		{
			get { return DateTime.Now.Ticks / 10000; }
		}

	}

}