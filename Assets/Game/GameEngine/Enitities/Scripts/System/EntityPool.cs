using System;
using System.Collections.Generic;
using Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Entities
{
    [Serializable]
    public sealed class EntityPool
    {
        [SerializeField]
        private Transform parent;
        
        [SerializeField]
        private MonoEntity prefab;
        
        [Space, ReadOnly, ShowInInspector]
        private readonly Queue<MonoEntity> availableEntities = new();

        public MonoEntity Get()
        {
            MonoEntity entity;
            if (this.availableEntities.Count > 0)
            {
                entity = this.availableEntities.Dequeue();
                entity.gameObject.hideFlags = HideFlags.None;
            }
            else
            {
                entity = GameObject.Instantiate(this.prefab, this.parent);
            }
            
            return entity;
        }

        public void Release(MonoEntity entity)
        {
            var entityObject = entity.gameObject;
            entityObject.SetActive(false);
            entityObject.hideFlags = HideFlags.HideInHierarchy;
            this.availableEntities.Enqueue(entity);
        }
    }
}