
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lite.Utility;


namespace Lite
{

	class GameServer : BaseServer
	{
		private LoopTimer configTimer;
		private LoopTimer tickTimer;

		protected override void OnStarted()
		{
			base.OnStarted();

			ConfigUtil.LoadConfig();

			AppFacade.Instance.Init();
			TemplateRegister.RegisterALL();
			TemplateManager.Instance.Init();

			// timers
			this.configTimer = new LoopTimer(ConfigUtil.ConfigUpdateTime, ConfigUtil.LoadConfig);
			this.configTimer.Start();
			this.tickTimer = new LoopTimer(ConfigUtil.ServerTickTime, Tick);
			this.tickTimer.Start();
		}

		protected override void OnStopped()
		{
			base.OnStopped();

			this.tickTimer.Stop();

			AppFacade.Instance.Close();
		}

		private void Tick(int dms)
		{
			//Log.Warn(""+dms);
			SceneManager.Instance.Tick(dms);
			EntityManager.Instance.Tick(dms);
		}


	}

}