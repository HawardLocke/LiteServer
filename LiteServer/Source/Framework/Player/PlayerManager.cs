using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite
{

	public sealed class PlayerManager : IManager
	{
		Dictionary<long, PlayerObject> mPlayerMap;

		public PlayerManager()
		{
			mPlayerMap = new Dictionary<long, PlayerObject>();
		}

		public override void Init()
		{
			base.Init();
		}

		public override void Destroy()
		{
			base.Destroy();
		}

		public bool ContainEntity(PlayerObject player)
		{
			return mPlayerMap.ContainsValue(player);
		}

		public PlayerObject GetPlayer(long playerGuid)
		{
			PlayerObject player = null;
			mPlayerMap.TryGetValue(playerGuid, out player);
			return player;
		}

		public void AddPlayer(PlayerObject player)
		{
			if (player == null)
			{
				Log.Error("PlayerManager.AddPlayer: player is null.");
				return;
			}
			if (ContainEntity(player))
			{
				Log.Error("PlayerManager.AddPlayer: player Repeated.");
				return;
			}
			long uid = GuidGenerator.GetLong();
			mPlayerMap.Add(uid, player);
		}

		public void RemovePlayer(PlayerObject player)
		{
			mPlayerMap.Remove(player.PlayerGuid);
		}

	}

}