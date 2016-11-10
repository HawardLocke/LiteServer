using System;
using System.Text;
using Lite.Timer;
using Lite.Utility;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;

namespace Lite
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

			this.NewSessionConnected += new SessionHandler<ClientSession>(OnSessionConnected);
			this.SessionClosed += new SessionHandler<ClientSession, CloseReason>(OnSessionDisconnected);
			this.NewRequestReceived += new RequestHandler<ClientSession, BinaryRequestInfo>(OnRequestReceived);
		}

		protected override void OnStopped()
		{
			base.OnStopped();

			this.NewSessionConnected -= new SessionHandler<ClientSession>(OnSessionConnected);
			this.SessionClosed -= new SessionHandler<ClientSession, CloseReason>(OnSessionDisconnected);
			this.NewRequestReceived -= new RequestHandler<ClientSession, BinaryRequestInfo>(OnRequestReceived);
		}

		protected virtual void OnSessionConnected(ClientSession session)
		{
			SessionManager.Instance.Add(session);
		}

		protected virtual void OnSessionDisconnected(ClientSession session, CloseReason reason)
		{
			SessionManager.Instance.Remove(session.uid);
		}

		protected virtual void OnRequestReceived(ClientSession session, BinaryRequestInfo requestInfo)
		{
			MessageHandler.Instance.HandlerMessage(session, requestInfo);
		}

	}
}
