
using Entitas;

namespace Lite
{
	[GameObjects]
	public sealed class PlayerComponent : IComponent
	{
		public long playerGuid;
		public string playerName;
	}

}