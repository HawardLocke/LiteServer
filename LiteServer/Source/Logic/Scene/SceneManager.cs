
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lite
{

	public class SceneManager : IManager
	{
		private Dictionary<int, Scene> mSceneMap = new Dictionary<int, Scene>();

		private int genSceneId = 1111;

		public Scene MainScene { private set; get; }

		public override void Init()
		{
			LoadMainScene();
		}

		public override void Destroy()
		{
			foreach (Scene scene in mSceneMap.Values)
			{
				scene.Destroy();
			}
		}

		public override void Update()
		{
			foreach(Scene scene in mSceneMap.Values)
			{
				scene.Update();
			}
		}

		public Scene GetScene(int sceneId)
		{
			Scene scene = null;
			mSceneMap.TryGetValue(genSceneId, out scene);
			return scene;
		}

		public void AddScene(Scene scene)
		{
			int id = GenSceneID();
			scene.SceneID = id;
			mSceneMap.Add(id, scene);
		}

		private int GenSceneID() { return ++genSceneId; }

		private void LoadMainScene()
		{
			Scene scene = new Scene();
			AddScene(scene);
			MainScene = scene;
			scene.Init();
		}

	}

}