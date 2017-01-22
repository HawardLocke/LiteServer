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
			LiteFacade.GetManager<SessionManager>().AddSession(session);
		}

		protected virtual void OnSessionDisconnected(WebClientSession session, CloseReason reason)
		{
			LiteFacade.GetManager<SessionManager>().RemoveSession(session.sessionGuid);
		}

		protected virtual void OnDataReceived(WebClientSession session, byte[] requestInfo)
		{
			LiteFacade.GetManager<MessageManager>().HandlerMessage(session, requestInfo);
		}

	}
}
