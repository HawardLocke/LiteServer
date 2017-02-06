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
			if (!AppFacade.GetManager<SessionManager>().AddSession(session))
			{
				session.Close(CloseReason.ApplicationError);
			}
		}

		protected virtual void OnSessionDisconnected(ClientSession session, CloseReason reason)
		{
			AppFacade.GetManager<SessionManager>().RemoveSession(session);
		}

		protected virtual void OnRequestReceived(ClientSession session, BinaryRequestInfo requestInfo)
		{
			AppFacade.GetManager<MessageManager>().HandlerMessage(session, requestInfo);
		}

	}
}
