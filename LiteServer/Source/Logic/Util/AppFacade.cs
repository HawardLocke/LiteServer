using System;
using System.Collections.Generic;
using System.Text;
using Lite;
using Lite.Message;
using Lite.Service;


namespace Lite
{
	class AppFacade : Singleton<AppFacade>
	{
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
			Console.WriteLine("recv Login");

			Login loginRet = new Login
			{
				Name = "Locke007back",
				Password = "666"
			};

			byte[] bytesRet = Google.Protobuf.MessageExtensions.ToByteArray(loginRet);

			session.SendPacket((ushort)PBX.MsgID.Login, bytesRet);

			return 0;
		}

		public void Init()
		{
			// test
			MessageHandler.Instance.RegisterHandler((ushort)PBX.MsgID.Login, test_OnLogin);
		}

		public void Close()
		{
		}

	}
}
