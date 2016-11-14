
using System;
using System.Collections.Generic;


namespace Lite
{

	interface IMsgHandler
	{
		void Register();
	}

	sealed class MsgHandlerManager : Singleton<MsgHandlerManager>
	{
		private List<IMsgHandler> mHandlerList = new List<IMsgHandler>();
		public void Init()
		{
			mHandlerList.Add(new LoginHandler());
			mHandlerList.Add(new SceneHandler());

			foreach(var handler in mHandlerList)
			{
				handler.Register();
			}
		}

		public void Destroy()
		{

		}

	}

}