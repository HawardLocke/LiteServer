
using Entitas;

namespace Lite
{
	[GameObjects]
	public sealed class PlayerInfoComponent : IComponent
	{
		public long playerGuid;

		public string playerName;

	}

}