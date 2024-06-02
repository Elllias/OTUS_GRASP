using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameEngine.Enums;
using GameEngine.Systems;
using Newtonsoft.Json;
using SaveSystem.Data;
using SaveSystem.Interfaces;
using SaveSystem.Utils;
using UnityEngine;

namespace SaveSystem
{
    public class PlayerSaveLoader : ISaveLoader<PlayerResources>
    {
        private const string PLAYER_FILE_NAME = "Player.txt";
        
        private readonly string _savePath = Application.persistentDataPath;
        
        public void Save(PlayerResources service)
        {
            var resources = PlayerToData(service.GetResources());
            var json = Encryptor.Encrypt(JsonConvert.SerializeObject(resources));
            
            var path = Path.Combine(_savePath, PLAYER_FILE_NAME);
            
            File.WriteAllText(path, json);
        }

        public void Load(PlayerResources service)
        {
            var path = Path.Combine(_savePath, PLAYER_FILE_NAME);
            var json = Encryptor.Decrypt(File.ReadAllText(path));
            
            var resourcesData = JsonConvert.DeserializeObject<PlayerData>(json);
            service.SetResources(resourcesData.Resources);
        }
        
        private PlayerData PlayerToData(Dictionary<ResourceType, int> resources)
        {
            return new PlayerData
            {
                Resources = resources
            };
        }
    }
}