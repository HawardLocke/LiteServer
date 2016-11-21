

using System;
using System.Collections;
using System.Collections.Generic;


namespace Lite.Event
{
	using ListenerList = List<IEventListener>;

	public class EventManager : IManager
	{
		private Dictionary<ushort, ListenerList> mListenerMap;

		public override void Init()
		{
			mListenerMap = new Dictionary<ushort, List<IEventListener>>();
		}

		public override void Destroy()
		{

		}

		public void RegisterListener(ushort eventID, IEventListener listener)
		{
			ListenerList list = null;
			mListenerMap.TryGetValue(eventID, out list);
			if (list == null)
			{
				list = new ListenerList();
				mListenerMap.Add(eventID, list);
			}
			if (!list.Contains(listener))
				list.Add(listener);
		}


		public void UnregisterListener(ushort eventID, IEventListener listener)
		{
			ListenerList list = null;
			mListenerMap.TryGetValue(eventID, out list);
			if (list != null)
			{
				if (list.Contains(listener))
					list.Remove(listener);
			}
		}


		public void PushEvent(IEvent evt)
		{
			ListenerList list = null;
			mListenerMap.TryGetValue(evt.id, out list);
			if (list != null)
			{
				for (int i = 0; i < list.Count; ++i)
				{
					IEventListener listener = list[i];
					if (null != listener)
						listener.OnEvent(evt);
				}
			}
		}

	}
}
