using System;
using System.Text;
using Lite.Utility;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.WebSocket;

namespace Lite.Network
{
	class BaseWebSocketServer : WebSocketServer<WebClientSession>
	{

		public BaseWebSocketServer()
		{
		}

		protected override void OnStarted()
		{
			base.OnStarted();

			this.NewSessionConnected += new SessionHandler<WebClientSession>(OnSessionConnected);
			this.SessionClosed += new SessionHandler<WebClientSession, CloseReason>(OnSessionDisconnected);
			this.NewDataReceived += new SessionHandler<WebClientSession, byte[]>(OnDataReceived);
		}

		protected override void OnStopped()
		{
			base.OnStopped();

			this.NewSessionConnected -= new SessionHandler<WebClientSession>(OnSessionConnected);
			this.SessionClosed -= new SessionHandler<WebClientSession, CloseReason>(OnSessionDisconnected);
			this.NewDataReceived -= new SessionHandler<WebClientSession, byte[]>(OnDataReceived);
		}

		protected virtual void OnSessionConnected(WebClientSession session)
		{
			//Log.Warn("connect");
			if (!AppFacade.GetManager<SessionManager>().AddSession(session))
			{
				session.Close(CloseReason.ApplicationError);
			}
		}

		protected virtual void OnSessionDisconnected(WebClientSession session, CloseReason reason)
		{
			//Log.Warn("disconnect");
			AppFacade.GetManager<SessionManager>().RemoveSession(session);
		}

		protected virtual void OnDataReceived(WebClientSession session, byte[] requestInfo)
		{
			//Log.Warn("recv data");
			AppFacade.GetManager<MessageManager>().HandlerMessage(session, requestInfo);
		}

	}
}
