using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite
{

	public sealed class EntityManager : Singleton<EntityManager>, IManager
	{
		private Dictionary<long, EntityObject> mEntityMap = new Dictionary<long, EntityObject>();

		public void Init()
		{

		}

		public void Destroy() 
		{

		}

		public void Tick(long dms)
		{
			foreach (EntityObject ent in mEntityMap.Values)
			{
				
			}
		}

		public EntityObject GetEntity(long uid)
		{
			EntityObject ent = null;
			mEntityMap.TryGetValue(uid, out ent);
			return ent;
		}

		public EntityObject SpawnEntity()
		{
			EntityObject ent = new EntityObject();
			long uid = GuidGenerator.GetLong();
			ent.EntityID = uid;
			mEntityMap.Add(uid, ent);
			return ent;
		}

		public void DestroyEntity(long uid)
		{
			EntityObject ent = GetEntity(uid);
			if (ent != null)
			{
				mEntityMap.Remove(uid);
			}
		}

	}

}
