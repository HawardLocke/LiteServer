using System;
using System.Text;
using Lite.Utility;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;

namespace Lite.Network
{
	class BaseSocketServer : AppServer<ClientSession, BinaryRequestInfo>
	{

		public BaseSocketServer()
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
			//LiteFacade.PushEvent();
			LiteFacade.GetManager<SessionManager>().AddSession(session);
		}

		protected virtual void OnSessionDisconnected(ClientSession session, CloseReason reason)
		{
			LiteFacade.GetManager<SessionManager>().RemoveSession(session.sessionGuid);
		}

		protected virtual void OnRequestReceived(ClientSession session, BinaryRequestInfo requestInfo)
		{
			LiteFacade.GetManager<MessageManager>().HandlerMessage(session, requestInfo);
		}

	}
}
