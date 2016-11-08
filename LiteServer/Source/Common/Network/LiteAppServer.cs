using System;
using System.Text;
using LiteServer.Timer;
using LiteServer.Utility;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;

namespace LiteServer
{
	class LiteAppServer : AppServer<ClientSession, BinaryRequestInfo>
	{

		public LiteAppServer()
			: base(new DefaultReceiveFilterFactory<ClientReceiveFilter, BinaryRequestInfo>())
		{
		}

		protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
		{
			return base.Setup(rootConfig, config);
		}

		protected override void OnStarted()
		{
			base.OnStarted();
			AppFacade.Instance.Init();

			this.NewSessionConnected += new SessionHandler<ClientSession>(OnSessionConnected);
			this.SessionClosed += new SessionHandler<ClientSession, CloseReason>(OnSessionDisconnected);
			this.NewRequestReceived += new RequestHandler<ClientSession, BinaryRequestInfo>(OnRequestReceived);
		}

		protected override void OnStopped()
		{
			base.OnStopped();
			AppFacade.Instance.Close();

			this.NewSessionConnected -= new SessionHandler<ClientSession>(OnSessionConnected);
			this.SessionClosed -= new SessionHandler<ClientSession, CloseReason>(OnSessionDisconnected);
			this.NewRequestReceived -= new RequestHandler<ClientSession, BinaryRequestInfo>(OnRequestReceived);
		}

		void OnSessionConnected(ClientSession session)
		{
			SessionManager.Instance.Add(session);
		}

		void OnSessionDisconnected(ClientSession session, CloseReason reason)
		{
			SessionManager.Instance.Remove(session.uid);
		}

		void OnRequestReceived(ClientSession session, BinaryRequestInfo requestInfo)
		{
			MessageHandler.Instance.HandlerMessage(session, requestInfo);
		}
	}
}
