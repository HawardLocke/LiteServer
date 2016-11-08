using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteServer
{

	public sealed class EntityManager : Singleton<EntityManager>, IManager
	{
		private Dictionary<long, EntityObject> mEntityMap = new Dictionary<long, EntityObject>();

		public void Init()
		{

		}

		public void Destroy() { }

		public EntityObject SpawnEntity()
		{
			return null;
		}

		public void DestroyEntity()
		{

		}

	}

}
