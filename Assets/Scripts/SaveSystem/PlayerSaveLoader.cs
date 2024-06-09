using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameEngine.Enums;
using GameEngine.Systems;
using Newtonsoft.Json;
using SaveSystem.Data;
using SaveSystem.Interfaces;
using SaveSystem.Systems;
using SaveSystem.Utils;
using UnityEngine;

namespace SaveSystem
{
    public class PlayerSaveLoader : SaveLoader<PlayerResources, PlayerData>
    {
        protected override PlayerData ConvertToData(PlayerResources service)
        {
            var resources = service.GetResources();
            
            return new PlayerData
            {
                Resources = resources
            };
        }

        protected override void SetupData(PlayerResources service, PlayerData resourceContainerData)
        {
            service.SetResources(resourceContainerData.Resources);
        }
    }
}