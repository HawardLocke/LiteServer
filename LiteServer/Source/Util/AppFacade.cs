using System;
using System.Collections.Generic;
using System.Text;
using LiteServer;
using LiteServer.Message;
using LiteServer.Service;
using LiteServer.Timer;

namespace LiteServer
{
	class AppFacade : Singleton<AppFacade>
	{
		static AppFacade server;
		private RedisTimer redis;
		private ConfigTimer config;
		private HttpServer http;

		/*void testProto()
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

		}*/

		int test_OnLogin(ClientSession session, byte[] bytes)
		{
			Login loginMsg = Login.Parser.ParseFrom(bytes);
			Console.WriteLine("on test_OnLogin");
			Console.WriteLine(loginMsg.Name);
			Console.WriteLine(loginMsg.Password);

			Login loginRet = new Login
			{
				Name = "Locke007back",
				Password = "666"
			};

			byte[] bytesRet = Google.Protobuf.MessageExtensions.ToByteArray(loginRet);

			session.SendMessage((ushort)PBX.MsgID.Login, bytesRet);

			return 0;
		}

		public void Init()
		{
			config = new ConfigTimer(); config.Start();
			//redis = new RedisTimer(); redis.Start();
			//http = new HttpServer(7077); http.Start();
			
			// test
			MessageHandler.Instance.RegisterHandler((ushort)PBX.MsgID.Login, test_OnLogin);
		}

		public void Close()
		{
			//redis.Stop(); redis = null;
			config.Stop(); config = null;
			http.Stop(); http = null;
		}
	}
}
