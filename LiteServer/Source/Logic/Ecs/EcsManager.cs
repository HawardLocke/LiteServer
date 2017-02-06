
using Entitas;

namespace Lite
{
	public class ECSManager : IManager
	{
		Systems systems;

		public override void Init()
		{
			Pools pools = Pools.sharedInstance;
			pools.SetAllPools();

			systems = new Systems()
				.Add(pools.CreateSystem(new VelocitySystem()))
				.Add(pools.CreateSystem(new RigidBodySystem()))
				.Add(pools.CreateSystem(new EnergyCollectorSystem()))
				;

			systems.Initialize();

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


	}
}