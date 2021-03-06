﻿using Entitas;

namespace Lite
{
	public sealed class VelocitySystem : ISetPools, IExecuteSystem
	{

		Group[] _relatedGroups;

		public void SetPools(Pools pools)
		{
			var matcher = Matcher.AllOf(CoreMatcher.Velocity, CoreMatcher.Transform);
			_relatedGroups = new[] {
				pools.core.GetGroup(matcher),
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
					var pos = e.transform.position;
					e.ReplaceTransform(pos + e.velocity.value * dt, e.transform.rotation);
				}
			}
		}
	}

}