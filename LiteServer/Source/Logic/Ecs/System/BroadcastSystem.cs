using Entitas;

namespace Lite
{
	public sealed class BoradcastSystem : ISetPools, IExecuteSystem
	{

		Group[] _broadcastGroups;

		public void SetPools(Pools pools)
		{
			var matcher = Matcher.AllOf(GameObjectsMatcher.Broadcast);
			_broadcastGroups = new[] {
				pools.gameObjects.GetGroup(matcher)
			};
		}

		public void Execute()
		{
			Log.Warn("bro");
			foreach (var group in _broadcastGroups)
			{
				foreach (var e in group.GetEntities())
				{
					var pos = e.transform.position;
					e.ReplaceTransform(pos + e.velocity.value, e.transform.angle);
				}
			}
		}
	}

}