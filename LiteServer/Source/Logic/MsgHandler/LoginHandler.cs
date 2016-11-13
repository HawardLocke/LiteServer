
using System;
using Google.Protobuf;


namespace Lite
{
	class LoginHandler : IMsgHandler
	{
		public void Register()
		{
			MessageHandler.Instance.RegisterHandler((ushort)PBX.MsgID.LoginRequest, OnLoginRequest);
			MessageHandler.Instance.RegisterHandler((ushort)PBX.MsgID.EnterGameRequest, OnEnterGameRequest);
		}

		int OnLoginRequest(ClientSession session, byte[] bytes)
		{
			LoginRequest loginMsg = LoginRequest.Parser.ParseFrom(bytes);
			Log.Info(string.Format("recv Login,{0},{1}.", loginMsg.Account, loginMsg.Password));

			LoginResponse loginRet = new LoginResponse
			{
				Result = 0
			};
			session.SendPacket(PBX.MsgID.LoginResponse, loginRet);

			return 0;
		}

		int OnEnterGameRequest(ClientSession session, byte[] bytes)
		{
			EnterGameRequest recvMsg = EnterGameRequest.Parser.ParseFrom(bytes);
			Log.Info(string.Format("recv EnterGame,{0}.", recvMsg.RoleIndex));

			EnterGameResponse enterRet = new EnterGameResponse();
			enterRet.Result = 0;
			session.SendPacket(PBX.MsgID.EnterGameResponse, enterRet);

			return 0;
		}

	}
}