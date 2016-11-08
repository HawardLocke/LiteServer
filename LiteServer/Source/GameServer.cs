using System;
using System.Text;
using LiteServer.Timer;
using LiteServer.Utility;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;

namespace LiteServer
{
	class GameServer : AppServer<ClientSession, BinaryRequestInfo>
	{

		public GameServer()
			: base(new DefaultReceiveFilterFactory<ClientReceiveFilter, BinaryRequestInfo>())
		{
		}

		protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
		{
			return base.Setup(rootConfig, config);
		}

		void testProto()
		{
			Login login = new Login
			{
				Name = "Foo",
				Password = "foo@bar",
				Infos = { new ExtraInfo { Number = 666 } }
			};

			byte[] bytes = Google.Protobuf.MessageExtensions.ToByteArray(login);

			Login restored = Login.Parser.ParseFrom(bytes);

			Console.WriteLine(restored.Name);
			Console.WriteLine(restored.Password);

		}

		protected override void OnStarted()
		{
			base.OnStarted();
			ServerUtil.instance.Init();

			this.NewSessionConnected += new SessionHandler<ClientSession>(OnSessionConnected);
			this.SessionClosed += new SessionHandler<ClientSession, CloseReason>(OnSessionDisconnected);
			this.NewRequestReceived += new RequestHandler<ClientSession, BinaryRequestInfo>(OnRequestReceived);

			Log.Debug(typeof(GameServer), "test log - {0}", "debug");
			Log.Info(typeof(GameServer), "test log - {0}", "info");
			Log.Warn(typeof(GameServer), "test log - {0}", "warn");
			Log.Fatal(typeof(GameServer), "test log - {0}", "fatal");
			Log.Error(typeof(GameServer), "test log - {0}", "error");
		}

		protected override void OnStopped()
		{
			base.OnStopped();
			ServerUtil.instance.Close();

			this.NewSessionConnected -= new SessionHandler<ClientSession>(OnSessionConnected);
			this.SessionClosed -= new SessionHandler<ClientSession, CloseReason>(OnSessionDisconnected);
			this.NewRequestReceived -= new RequestHandler<ClientSession, BinaryRequestInfo>(OnRequestReceived);
		}

		void OnSessionConnected(ClientSession session)
		{
			SessionManager.Instance.Add(session);
			SocketUtil.instance.OnSessionConnected(session);
		}

		void OnSessionDisconnected(ClientSession session, CloseReason reason)
		{
			SessionManager.Instance.Remove(session.uid);
			SocketUtil.instance.OnSessionClosed(session, reason);
		}

		void OnRequestReceived(ClientSession session, BinaryRequestInfo requestInfo)
		{
			SocketUtil.instance.OnRequestReceived(session, requestInfo);
		}
	}
}
