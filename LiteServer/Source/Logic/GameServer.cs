
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lite.Utility;


namespace Lite
{

	class GameServer : Network.BaseWebSocketServer
	{
		private LoopTimer configTimer;
		private LoopTimer tickTimer;
		private LoopTimer rapidTickTimer;

		protected override void OnStarted()
		{
			base.OnStarted();

			GameTimer.Start();

			ConfigUtil.LoadConfig();
			
			AppFacade.Instance.Init();
			
			MsgHandlerManager.Instance.Init();

			// timers
			this.configTimer = new LoopTimer(ConfigUtil.ConfigUpdateTime, ConfigUtil.LoadConfig);
			this.configTimer.Start();
			this.tickTimer = new LoopTimer(ConfigUtil.ServerTickTime, Tick);
			this.tickTimer.Start();
			this.rapidTickTimer = new LoopTimer(ConfigUtil.ServerRapidTickTime, RapidTick);
			this.rapidTickTimer.Start();
		}

		protected override void OnStopped()
		{
			base.OnStopped();

			this.tickTimer.Stop();
			this.rapidTickTimer.Stop();

			AppFacade.Instance.Destroy();
		}

		private void Tick(int ms)
		{
			AppFacade.Instance.Tick();
			//Log.Warn(""+ms);
		}

		private void RapidTick(int ms)
		{
			AppFacade.Instance.RapidTick();
			//Log.Warn("" + ms);
		}

	}

}