
using System;
using System.Collections;
using System.Collections.Generic;

using Entitas;


namespace Lite
{

	public class EntityManager : IManager
	{
		private Dictionary<int, Entity> _allEntityMap = new Dictionary<int, Entity>();
		private Dictionary<long, Entity> _playerEntityMap = new Dictionary<long, Entity>();


		public Entity FindEntity(int id)
		{
			Entity ent = null;
			_allEntityMap.TryGetValue(id, out ent);
			return ent;
		}

		public Entity FindPlayerEntity(long guid)
		{
			Entity ent = null;
			_playerEntityMap.TryGetValue(guid, out ent);
			return ent;
		}

		public void DestroyEntity(Entity ent)
		{
			int id = ent.creationIndex;

			_allEntityMap.Remove(id);

			if (ent.hasPlayerInfo && _playerEntityMap.ContainsKey(ent.playerInfo.playerGuid))
				_playerEntityMap.Remove(ent.playerInfo.playerGuid);

			Pools.sharedInstance.gameObjects.DestroyEntity(ent);
		}

		public void DestroyAllEntities()
		{
			_allEntityMap.Clear();
			_playerEntityMap.Clear();

			Pools.sharedInstance.gameObjects.DestroyAllEntities();
		}

		public Entity CreateEnergyBall(Vector2 position, int energy)
		{
			Pools pools = Pools.sharedInstance;
			Entity ent = pools.gameObjects.CreateEntity()
				.IsEnergyBall(true)
				.AddTransform(position, 0)
				.AddRigidBody(1, Vector2.zero, Vector2.zero)
				.AddEnergy(energy)
				;

			_allEntityMap.Add(ent.creationIndex, ent);

			return ent;
		}

		/*public Entity CreateMovable(Vector2 position, int mass, Vector2 velocity)
		{
			Pools pools = Pools.sharedInstance;
			Entity ent = pools.gameObjects.CreateEntity()
				.AddTransform(position, 0)
				.AddVelocity(velocity)
				;

			return ent;
		}

		public Entity CreateRigidMovable(Vector2 position, int mass, Vector2 force)
		{
			Pools pools = Pools.sharedInstance;
			Entity ent = pools.gameObjects.CreateEntity()
				.AddTransform(position, 0)
				.AddRigidBody(mass, force)
				;

			return ent;
		}*/

		public Entity CreatePlayer(long guid, string name, Vector2 position, int mass, Vector2 force, int energy, float collectRadius, float collectSpeed)
		{
			Pools pools = Pools.sharedInstance;
			Entity ent = pools.gameObjects.CreateEntity()
				.AddPlayerInfo(guid, name)
				.AddTransform(position, 0)
				.AddRigidBody(mass, force, Vector2.zero)
				.AddEnergy(energy)
				.AddEnergyCollector(collectRadius, collectSpeed)
				;

			_allEntityMap.Add(ent.creationIndex, ent);

			_playerEntityMap.Add(guid, ent);

			return ent;
		}

	}

}