

namespace Lite.Event
{
	public struct IEvent
	{
		public ushort id;

		public object body;

		public IEvent(ushort id, object body)
		{
			this.id = id;
			this.body = body;
		}

	}

}
