using System.Collections.Generic;
using UnityEngine;

namespace Leopotam.EcsLite.Entities
{
    public sealed class EntityManager
    {
        private EcsWorld world;

        private readonly Dictionary<int, Entity> entities = new();
        
        public void Initialize(EcsWorld world)
        {
            Entity[] entities = GameObject.FindObjectsOfType<Entity>();
            for (int i = 0, count = entities.Length; i < count; i++)
            {
                Entity entity = entities[i];
                entity.Initialize(world);
                this.entities.Add(entity.Id, entity);
            }
            
            this.world = world;
        }

        public Entity Create(Entity prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            Entity entity = GameObject.Instantiate(prefab, position, rotation, parent);
            entity.Initialize(this.world);
            this.entities.Add(entity.Id, entity);
            return entity;
        }

        public void Destroy(int id)
        {
            if (this.entities.Remove(id, out Entity entity))
            {
                entity.Dispose();
                GameObject.Destroy(entity.gameObject);
            }
        }

        public Entity Get(int id)
        {
            return this.entities[id];
        }
    }
}