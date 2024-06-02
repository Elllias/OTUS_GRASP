using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameEngine
{
    //Нельзя менять!
    [Serializable]
    public sealed class UnitManager
    {
        [SerializeField]
        private Transform container;

        [ShowInInspector, ReadOnly]
        private HashSet<Unit> sceneUnits = new();

        public UnitManager()
        {
        }

        public UnitManager(Transform container)
        {
            this.container = container;
        }
        
        public void SetupUnits(IEnumerable<Unit> units)
        {
            this.sceneUnits = new HashSet<Unit>(units);
        }

        public void SetContainer(Transform container)
        {
            this.container = container;
        }

        [Button]
        public Unit SpawnUnit(Unit prefab, Vector3 position, Quaternion rotation)
        {
            var unit = Object.Instantiate(prefab, position, rotation, this.container);
            this.sceneUnits.Add(unit);
            return unit;
        }

        [Button]
        public void DestroyUnit(Unit unit)
        {
            if (this.sceneUnits.Remove(unit))
            {
                Object.Destroy(unit.gameObject);
            }
        }

        public IEnumerable<Unit> GetAllUnits()
        {
            return this.sceneUnits;
        }
    }
}