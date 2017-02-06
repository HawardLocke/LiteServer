using Entitas;

namespace Lite
{
	public sealed class EnergyCollectorSystem : ISetPools, IExecuteSystem
	{

		Group[] _relatedGroups;

		public void SetPools(Pools pools)
		{
			var matcher = Matcher.AllOf(GameObjectsMatcher.Energy, GameObjectsMatcher.EnergyCollector);
			_relatedGroups = new[] {
				pools.gameObjects.GetGroup(matcher)
			};
		}

		public void Execute()
		{
			float dt = GameTimer.deltaTime;

			foreach (var group in _relatedGroups)
			{
				foreach (var e in group.GetEntities())
				{
					//e.energyCollector.radius;
					//e.energyCollector.speed;
					//check region around and collect
				}
			}
		}
	}

}