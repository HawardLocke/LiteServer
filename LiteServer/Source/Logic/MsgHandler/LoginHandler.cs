
using System;
using System.IO;
using ProtoBuf;
using Protocol;
using Lite.Network;


namespace Lite
{
	class LoginHandler : IMsgHandler
	{
		public void Register()
		{
			var msgMgr = AppFacade.GetManager<MessageManager>();
			msgMgr.RegisterHandler((int)MsgID.csLogin, OnLogin);
		}

		int OnLogin(IClientSession session, byte[] bytes)
		{
			csLogin loginMsg = csLogin.Parser.ParseFrom(bytes);
			//csLogin loginMsg = ProtoUtil.ParseFrom<csLogin>(bytes);

			/*csLogin loginMsg = new csLogin
			{
				account = "Locke",
				password = "******"
			};

			byte[] data = null;
			using (var stream = new MemoryStream())
			{
				ProtoBuf.Serializer.Serialize(stream, loginMsg);
				stream.Flush();
				data = stream.ToArray();
			}*/

			Log.Info(string.Format("recv Login,{0},{1}.", loginMsg.Account, loginMsg.Password));

			scLoginRet loginRet = new scLoginRet
			{
				Result = 0
			};
			session.SendPacket((int)MsgID.scLoginRet, loginRet);

			return 0;
		}

	}
}