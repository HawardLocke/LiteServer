
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lite.Utility;


namespace Lite
{

	class GameServer : Network.BaseServer
	{
		private LoopTimer configTimer;
		private LoopTimer tickTimer;

		protected override void OnStarted()
		{
			base.OnStarted();

			ConfigUtil.LoadConfig();
			// framework
			LiteFacade.Instance.Create();
			TemplateRegister.RegisterALL();
			LiteFacade.Instance.Init();
			// logic
			MsgHandlerManager.Instance.Init();

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

			LiteFacade.Instance.Destroy();
		}

		private void Tick(int dms)
		{
			//Log.Warn(""+dms);
			LiteFacade.GetManager<SceneManager>().Tick(dms);
			LiteFacade.GetManager<EntityManager>().Tick(dms);
		}


	}

}