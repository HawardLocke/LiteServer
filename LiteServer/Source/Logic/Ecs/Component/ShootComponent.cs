
using Entitas;

namespace Lite
{
	[GameObjects]
	public sealed class ShootComponent : IComponent
	{
		public int weaponId;
		public int weaponLevel;
	}

}