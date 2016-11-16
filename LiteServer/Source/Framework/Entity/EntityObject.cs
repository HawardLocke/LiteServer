using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lite
{
	public class EntityObject : IEntity
	{
		private int mEntityID = 0;
		public int EntityID
		{
			get { return mEntityID; }
			set { mEntityID = value; }
		}

		private int mSceneID = 0;
		public int SceneID
		{
			get { return mSceneID; }
			set { mSceneID = value; }
		}

		public virtual void OnCreate()
		{

		}

		public virtual void OnDestroy()
		{

		}


	}

}
