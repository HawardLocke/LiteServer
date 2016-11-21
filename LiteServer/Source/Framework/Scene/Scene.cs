
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

		public void Broadcast(PBX.MsgID msgId, Google.Protobuf.IMessage msg)
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
			enterMsg.PlayerInfo = new gcPlayerInfo();
			var playerInfo = enterMsg.PlayerInfo;
			playerInfo.PlayerGuid = player.PlayerGuid;
			playerInfo.Name = "zhang_san";
			playerInfo.Career = 233;
			playerInfo.Level = 666;
			Broadcast(PBX.MsgID.gcOtherEnterScene, enterMsg);
		}

		public void OnPlayerEnterDone(PlayerObject player)
		{
			gcNearbyPlayerInfo nearbyInfo = new gcNearbyPlayerInfo();
			foreach (var otherPlayer in mPlayerMap.Values)
			{
				gcPlayerInfo playerInfo = new gcPlayerInfo();
				playerInfo.PlayerGuid = otherPlayer.PlayerGuid;
				playerInfo.Name = "zhang_san";
				playerInfo.Career = 233;
				playerInfo.Level = 666;
				nearbyInfo.PlayerInfoList.Add(playerInfo);
			}
			player.SendPacket(PBX.MsgID.gcNearbyPlayerInfo, nearbyInfo);
		}

	}

}