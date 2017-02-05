
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lite.Protocol;


namespace Lite
{

	public class Scene
	{
		public int SceneID;

		public Scene()
		{
			
		}

		public void Init()
		{

		}

		public void Destroy()
		{

		}

		public void Update()
		{

		}

		

		public void Broadcast(ushort msgId, ProtoBuf.IExtensible msg)
		{
			/*foreach(var player in mPlayerMap.Values)
			{
				player.SendPacket(msgId, msg);
			}*/
		}

		public void OnPlayerEnter()
		{
			/*Log.Info("Player Enter Scene.");
			gcOtherEnterScene enterMsg = new gcOtherEnterScene();
			enterMsg.ret = 99;
			enterMsg.guid = (int)player.PlayerGuid;*/

			//gcEnterScene info = new gcEnterScene();
			//info.sceneId = 99999;
			//enterMsg.info = info;
			/*var playerInfo = new gcPlayerInfo();
			playerInfo.playerGuid = player.PlayerGuid;
			playerInfo.name = "zhang_san";
			playerInfo.career = 233;
			playerInfo.level = 666;
			playerInfo.x = 666;
			playerInfo.y = 666;
			enterMsg.playerInfo = playerInfo;*/

			//Broadcast((ushort)MsgID.gcOtherEnterScene, enterMsg);
		}

		public void OnPlayerEnterDone()
		{
			/*gcNearbyPlayerInfo nearbyInfo = new gcNearbyPlayerInfo();
			foreach (var otherPlayer in mPlayerMap.Values)
			{
				gcPlayerInfo playerInfo = new gcPlayerInfo();
				playerInfo.playerGuid = 1;// otherPlayer.PlayerGuid;
				playerInfo.name = "zhang_san";
				playerInfo.career = 233;
				playerInfo.level = 666;
				playerInfo.x = 666;
				playerInfo.y = 666;
				nearbyInfo.playerInfoList.Add(playerInfo);
			}
			player.SendPacket((ushort)MsgID.gcNearbyPlayerInfo, nearbyInfo);*/
		}

	}

}