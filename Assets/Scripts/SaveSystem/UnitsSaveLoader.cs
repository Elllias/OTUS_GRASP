using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameEngine;
using GameEngine.ScriptableObjects;
using Lessons.Architecture.DI;
using Newtonsoft.Json;
using SaveSystem.Data;
using SaveSystem.Interfaces;
using SaveSystem.Systems;
using SaveSystem.Utils;
using UnityEngine;

namespace SaveSystem
{
    public sealed class UnitsSaveLoader : SaveLoader<UnitManager, UnitContainerData>
    {
        protected override UnitContainerData ConvertToData(UnitManager service)
        {
            var unitsData = new List<UnitData>();

            foreach (var unit in service.GetAllUnits())
            {
                var unitPosition = unit.Position;
                var unitRotation = unit.Rotation;
                
                var data = new UnitData
                {
                    Type = unit.Type,
                    HealthPoints = unit.HitPoints,
                    PositionX = unitPosition.x,
                    PositionY = unitPosition.y,
                    PositionZ = unitPosition.z,
                    RotationX = unitRotation.x,
                    RotationY = unitRotation.y,
                    RotationZ = unitRotation.z
                };
                
                unitsData.Add(data);
            }

            var unitsContainerData = new UnitContainerData
            {
                UnitsData = unitsData
            };
            
            return unitsContainerData;
        }

        protected override void SetupData(UnitManager service, UnitContainerData resourceContainerData)
        {
            var currentUnits = service.GetAllUnits().ToList();
            var unitsConfig = ServiceLocator.GetService<UnitsConfig>();
            var units = new List<Unit>();
            
            foreach (var unit in currentUnits)
            {
                service.DestroyUnit(unit);
            }
            
            foreach (var unitData in resourceContainerData.UnitsData)
            {
                var prefab = unitsConfig.GetPrefab(unitData.Type);
                var position = new Vector3(unitData.PositionX, unitData.PositionY, unitData.PositionZ);
                var rotation = Quaternion.Euler(unitData.RotationX, unitData.RotationY, unitData.RotationZ);

                var unit = service.SpawnUnit(prefab, position, rotation);
                unit.HitPoints = unitData.HealthPoints;

                units.Add(unit);
            }
            
            service.SetupUnits(units);
        }
    }
}