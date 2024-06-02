using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameEngine;
using GameEngine.ScriptableObjects;
using Newtonsoft.Json;
using SaveSystem.Data;
using SaveSystem.Interfaces;
using SaveSystem.Utils;
using UnityEngine;

namespace SaveSystem
{
    internal sealed class UnitsSaveLoader : ISaveLoader<UnitManager>
    {
        private const string UNITS_FILE_NAME = "Units.txt";
        
        private readonly string _savePath = Application.persistentDataPath;
        private readonly UnitsConfig _unitsConfig;
        
        public UnitsSaveLoader(UnitsConfig config)
        {
            _unitsConfig = config;
        }
        
        public void Save(UnitManager service)
        {
            var resources = UnitToData(service.GetAllUnits());
            var json = Encryptor.Encrypt(JsonConvert.SerializeObject(resources));
            
            var path = Path.Combine(_savePath, UNITS_FILE_NAME);
            
            File.WriteAllText(path, json);
        }

        public void Load(UnitManager service)
        {
            var units = new List<Unit>();
            var path = Path.Combine(_savePath, UNITS_FILE_NAME);
            var json = Encryptor.Decrypt(File.ReadAllText(path));
            
            var unitsData = JsonConvert.DeserializeObject<IEnumerable<UnitData>>(json);

            var currentUnits = service.GetAllUnits().ToList();

            foreach (var unit in currentUnits)
            {
                service.DestroyUnit(unit);
            }
            
            foreach (var unitData in unitsData)
            {
                var prefab = _unitsConfig.GetPrefab(unitData.Type);
                var position = new Vector3(unitData.PositionX, unitData.PositionY, unitData.PositionZ);
                var rotation = Quaternion.Euler(unitData.RotationX, unitData.RotationY, unitData.RotationZ);

                var unit = service.SpawnUnit(prefab, position, rotation);
                unit.HitPoints = unitData.HealthPoints;

                units.Add(unit);
            }
            
            service.SetupUnits(units);
        }
        
        private IEnumerable<UnitData> UnitToData(IEnumerable<Unit> units)
        {
            var unitsData = new List<UnitData>();

            foreach (var unit in units)
            {
                var unitPosition = unit.transform.position;
                var unitRotation = unit.transform.rotation.eulerAngles;
                
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
            
            return unitsData;
        }
    }
}