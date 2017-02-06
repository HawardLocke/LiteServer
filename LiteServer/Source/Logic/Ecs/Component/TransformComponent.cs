using Entitas;

namespace Lite
{

	[Core, GameObjects]
	public sealed class TransformComponent : IComponent
	{
		public Vector2 position;
		public float rotation;
	}

}
