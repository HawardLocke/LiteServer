using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lite.Utility;

namespace Lite
{
	class LoopTimer
	{
		public delegate void LoopFunc(int deltaMilliSeconds);
		private LoopFunc func = null;
		public delegate void LoopFuncVoid();
		private LoopFuncVoid funcVoid = null;
		System.Timers.Timer timer = null;
		private long lastTick = 0;

		public LoopTimer(int milliseconds, LoopFunc func)
		{
			timer = new System.Timers.Timer(milliseconds);
			timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimeUpdate);
			timer.AutoReset = true;
			this.func = func;
			this.lastTick = DateTime.Now.Ticks;
		}

		public LoopTimer(int milliseconds, LoopFuncVoid func)
		{
			timer = new System.Timers.Timer(milliseconds);
			timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimeUpdate);
			timer.AutoReset = true;
			this.funcVoid = func;
			this.lastTick = DateTime.Now.Ticks;
		}

		public void Start()
		{
			timer.Enabled = true;
			timer.Start();
		}

		public void Stop()
		{
			timer.Close();
		}

		private void OnTimeUpdate(object sender, System.Timers.ElapsedEventArgs e)
		{
			long curTick = DateTime.Now.Ticks;
			int dt = (int)(curTick - this.lastTick)/10000;// to milliseconds
			this.lastTick = curTick;
			if (func != null)
			{
				func(dt);
			}
			if (funcVoid != null)
			{
				funcVoid();
			}
		}
	}
}
