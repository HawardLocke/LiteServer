
using System;

namespace Lite
{

	public class GameTimer
	{
		private static long _startTime = 0;
		private static long _lastTickTime = 0;

		private static long _realtimeSinceStartup;
		private static long _deltaTimeMS;
		private static float _deltaTime;

		public static void Start()
		{
			_startTime = DateTime.Now.Ticks;
			_lastTickTime = _startTime;
		}

		public static void Tick()
		{
			long curTick = DateTime.Now.Ticks;
			_realtimeSinceStartup = (curTick - _startTime) / 10000;
			_deltaTimeMS = (curTick - _lastTickTime) / 10000;
			_deltaTime = (float)_deltaTimeMS / 1000;
			_lastTickTime = curTick;
		}

		public static long realtimeSinceStartup
		{
			get { return _realtimeSinceStartup; }
		}

		public static long tickTime
		{
			get { return DateTime.Now.Ticks / 10000; }
		}

		public static long deltaTimeMS
		{
			get { return _deltaTimeMS; }
		}

		public static float deltaTime
		{
			get { return _deltaTime; }
		}

	}

}