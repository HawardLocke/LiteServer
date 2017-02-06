using Entitas;

namespace Lite
{
	public sealed class RigidBodySystem : ISetPools, IExecuteSystem
	{

		Group[] _relatedGroups;

		public void SetPools(Pools pools)
		{
			var matcher = Matcher.AllOf(CoreMatcher.Transform, CoreMatcher.RigidBody);
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
					Vector2 ac = e.rigidBody.force / e.rigidBody.mass;
					e.rigidBody.velocity += ac * dt;
					e.transform.position = e.transform.position + e.rigidBody.velocity * dt;
				}
			}
		}
	}

}