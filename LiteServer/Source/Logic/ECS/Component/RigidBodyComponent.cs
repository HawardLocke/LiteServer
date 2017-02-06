
using Entitas;

namespace Lite
{
	[Core, GameObjects]
	public sealed class RigidBodyComponent : IComponent
	{
		public float mass;

		public Vector2 force;

		public Vector2 velocity;
	}

}