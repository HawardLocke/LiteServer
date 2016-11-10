
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lite
{

	class GameServer : LiteAppServer
	{
		protected override void OnStarted()
		{
			base.OnStarted();

			AppFacade.Instance.Init();
			TemplateManager.Instance.Init();
		}

		protected override void OnStopped()
		{
			base.OnStopped();

			AppFacade.Instance.Close();
		}

	}

}