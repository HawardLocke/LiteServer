using Entitas;


namespace Lite
{

	public class ObjectFactory
	{
		private static int sceneObjectIdCount = 0;

		public static Entity CreatePlayerEntity(long playerGuid, string playerName)
		{
			Pools pools = Pools.sharedInstance;
			Entity ent = pools.gameObjects.CreateEntity()
				.AddTransform(Vector2.zero, 0)
				.AddVelocity(Vector2.zero)
				.AddSceneObject(sceneObjectIdCount++)
/*				.AddBroadcast()*/
				.AddPlayer(playerGuid, playerName);

			return ent;
		}

		public static Entity CreateEnergyBallEntity(int energy)
		{
			Pools pools = Pools.sharedInstance;
			Entity ent = pools.gameObjects.CreateEntity()
				.AddTransform(Vector2.zero, 0)
				.AddVelocity(Vector2.zero)
				.AddSceneObject(sceneObjectIdCount++)
				.AddEnergyBall(energy);

			return ent;
		}

	}

}