
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

		private int genSceneId = 1111;

		public void Init()
		{

		}

		public void Destroy()
		{
		}

		public void Tick(long dms)
		{
			foreach(Scene scene in mSceneMap.Values)
			{
				scene.Tick(dms);
			}
		}

		public void AddScene(Scene scene)
		{
			int id = GenSceneID();
			mSceneMap.Add(id, scene);
		}

		public void RemoveScene()
		{

		}

		private int GenSceneID()
		{
			return ++genSceneId;
		}

	}

}