using System;
using System.Collections.Generic;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    public static class EntityUtils
    {
        public static Vector3 DistanceVector(IEntity start, IEntity end)
        {
            var startPosition = start.Get<IComponent_GetPosition>().Position;
            var endPosiiton = end.Get<IComponent_GetPosition>().Position;
            var vector = endPosiiton - startPosition;
            vector.y = 0;
            return vector;
        }

        public static Vector3 Direction(IEntity start, IEntity end)
        {
            return DistanceVector(start, end).normalized;
        }

        public static float Distance(IEntity start, IEntity end)
        {
            var vector = DistanceVector(start, end);
            return vector.magnitude;
        }
        
        public static void FilterEntities(IEnumerable<IEntity> entities, IEntityCondition condition, List<IEntity> buffer)
        {
            buffer.Clear();
            
            foreach (var entity in entities)
            {
                if (condition.IsTrue(entity))
                {
                    buffer.Add(entity);
                }
            }
        }
        
        public static void FilterEntities(IEnumerable<IEntity> entities, List<IEntity> buffer, Func<IEntity, bool> condition)
        {
            buffer.Clear();
            
            foreach (var entity in entities)
            {
                if (condition.Invoke(entity))
                {
                    buffer.Add(entity);
                }
            }
        }
        
        public static IEntity GetClosestByDistance(Vector3 basePosition, List<IEntity> entities)
        {
            if (entities.Count <= 0)
            {
                throw new Exception("Collection is empty!");
            }

            IEntity preferedEntity = null;

            var minCost = -1.0f;

            for (int i = 0, count = entities.Count; i < count; i++)
            {
                var resource = entities[i];
                var cost = Distance(basePosition, resource);
                if (preferedEntity == null || cost < minCost)
                {
                    preferedEntity = resource;
                    minCost = cost;
                }
            }
            
            return preferedEntity;
        }

        public static float Distance(Vector3 position, IEntity entity)
        {
            var resourcePosition = entity.Get<IComponent_GetPosition>().Position;
            var vector = resourcePosition - position;
            vector.y = 0;
            return vector.magnitude;
        }
    }
}