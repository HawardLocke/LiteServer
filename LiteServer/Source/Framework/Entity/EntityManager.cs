using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lite
{

	public sealed class EntityManager : IManager
	{
		private Dictionary<long, EntityObject> mEntityMap = new Dictionary<long, EntityObject>();

		private int mEntityIDGen = 1000;

		public override void Init()
		{

		}

		public override void Destroy() 
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

		public bool ContainEntity(EntityObject ent)
		{
			return mEntityMap.ContainsValue(ent);
		}

		public void AddEntity(EntityObject ent)
		{
			if (ent == null)
			{
				Log.Error("EntityManager.AddEntity: entity is null.");
				return;
			}
			if (ContainEntity(ent))
			{
				Log.Error("EntityManager.AddEntity: entity Repeated.");
				return;
			}
			ent.EntityID = mEntityIDGen++;
			mEntityMap.Add(ent.EntityID, ent);
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
