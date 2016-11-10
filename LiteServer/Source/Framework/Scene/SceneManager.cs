
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lite
{

	public class SceneManager : Singleton<SceneManager>, IManager
	{
		private Dictionary<int, Scene> mSceneMap = new Dictionary<int, Scene>();

		public void Init()
		{

		}

		public void Destroy()
		{
		}

	}

}