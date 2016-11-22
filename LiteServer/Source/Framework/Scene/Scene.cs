
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
		private int mID = 0;
		public int SceneID { get { return mID; } set { mID = value; } }

		private EntityManager mEntityMgr;

		private Dictionary<long, PlayerObject> mPlayerMap;

		public Scene()
		{
			mEntityMgr = new EntityManager();
			mPlayerMap = new Dictionary<long, PlayerObject>();
		}

		public void Init()
		{

		}

		public void Destroy()
		{

		}

		public void Tick(long ms)
		{

		}

		public void AddPlayer(long playerGuid, PlayerObject player)
		{
			AddEntity(player);
			mPlayerMap.Add(playerGuid, player);

			OnPlayerEnter(player);
		}

		public void AddEntity(EntityObject entity)
		{
			mEntityMgr.AddEntity(entity);
		}

		public void Broadcast(ushort msgId, ProtoBuf.IExtensible msg)
		{
			foreach(var player in mPlayerMap.Values)
			{
				player.SendPacket(msgId, msg);
			}
		}

		public void OnPlayerEnter(PlayerObject player)
		{
			Log.Info("Player Enter Scene.");
			gcOtherEnterScene enterMsg = new gcOtherEnterScene();
			enterMsg.ret = 99;
			enterMsg.guid = (int)player.PlayerGuid;
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
			Broadcast((ushort)PBX.MsgID.gcOtherEnterScene, enterMsg);
		}

		public void OnPlayerEnterDone(PlayerObject player)
		{
			gcNearbyPlayerInfo nearbyInfo = new gcNearbyPlayerInfo();
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
			player.SendPacket((ushort)PBX.MsgID.gcNearbyPlayerInfo, nearbyInfo);
		}

	}

}