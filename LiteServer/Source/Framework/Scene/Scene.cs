
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lite
{

	public class Scene
	{
		private int mID = 0;
		public int ID { get { return mID; } set { mID = value; } }

		private List<long> mEntityList = new List<long>();

		public void Tick(long ms)
		{

		}

	}

}