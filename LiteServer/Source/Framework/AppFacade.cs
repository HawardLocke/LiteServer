using System;
using System.Collections.Generic;
using System.Text;
using Lite;
using Lite.Message;
using Lite.Service;


namespace Lite
{
	class LiteFacade : Singleton<LiteFacade>
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

		

		public void Init()
		{
			// test
			//MessageHandler.Instance.RegisterHandler((ushort)PBX.MsgID.LoginRequest, test_OnLogin);
		}

		public void Close()
		{
		}

	}
}
