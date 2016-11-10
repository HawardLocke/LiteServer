using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lite
{
	public class EntityObject : IEntity
	{
		private long mEntityID = 0;
		public long EntityID
		{
			get { return mEntityID; }
			set { mEntityID = value; }
		}

		private int mSceneID = 0;

		public virtual void OnSpawn()
		{

		}

		public virtual void OnDestroy()
		{

		}


	}

}
