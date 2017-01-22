using Entitas;

namespace Lite
{
	public sealed class VelocitySystem : ISetPools, IExecuteSystem
	{

		Group[] _movableGroups;

		public void SetPools(Pools pools)
		{
			var matcher = Matcher.AllOf(CoreMatcher.Velocity, CoreMatcher.Transform);
			_movableGroups = new[] {
				pools.core.GetGroup(matcher),
				pools.gameObjects.GetGroup(matcher)
			};
		}

		public void Execute()
		{
			//Log.Warn("vel");
			foreach (var group in _movableGroups)
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