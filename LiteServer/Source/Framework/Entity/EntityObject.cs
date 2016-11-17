using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lite.Math;

namespace Lite
{
	public class EntityObject : IEntity
	{
		private int mEntityID = 0;
		public int EntityID
		{
			get { return mEntityID; }
		}

		private int mSceneID = 0;
		public int SceneID
		{
			get { return mSceneID; }
			set { mSceneID = value; }
		}

		private Vector2 mPosition;
		public Vector2 Position
		{
			get { return mPosition; }
		}

		public EntityObject(int entityId)
		{
			mEntityID = entityId;
			mSceneID = 0;
			mPosition = Vector2.Zero();
		}

		public virtual void OnCreate()
		{

		}

		public virtual void OnDestroy()
		{

		}

		public void SetPosition(float x, float y)
		{
			mPosition.Set(x, y);
		}


	}

}
