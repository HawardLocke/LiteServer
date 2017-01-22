
using Entitas;

namespace Lite
{
	public class EcsManager : IManager
	{
		Systems systems;

		public override void Init()
		{
			Pools pools = Pools.sharedInstance;
			pools.SetAllPools();

			systems = new Systems()
				.Add(pools.CreateSystem(new VelocitySystem()));

			systems.Initialize();

			//
			//test();
		}

		public override void Destroy()
		{
			systems.TearDown();
		}

		public override void Update()
		{
			systems.Execute();
			systems.Cleanup();
		}

		//public void GetSystem()

		private void test()
		{
			Pools.sharedInstance.core.CreateEntity()
			   .AddTransform(Vector2.zero, 0)
			   .AddVelocity(Vector2.zero);
		}

	}
}