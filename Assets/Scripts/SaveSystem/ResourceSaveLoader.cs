using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameEngine;
using Newtonsoft.Json;
using SaveSystem.Data;
using SaveSystem.Interfaces;
using SaveSystem.Systems;
using SaveSystem.Utils;
using UnityEngine;

namespace SaveSystem
{
    public sealed class ResourceSaveLoader : SaveLoader<ResourceService, ResourceContainerData>
    {
        protected override ResourceContainerData ConvertToData(ResourceService service)
        {
            var resourcesData = new List<ResourceData>();
            var resources = service.GetResources();

            foreach (var resource in resources)
            {
                var data = new ResourceData
                {
                    Id = resource.ID,
                    Amount = resource.Amount
                };

                resourcesData.Add(data);
            }

            var resourcesContainerData = new ResourceContainerData
            {
                ResourcesData = resourcesData
            };
            
            return resourcesContainerData;
        }

        protected override void SetupData(ResourceService service, ResourceContainerData resourceContainerData)
        {
            var resources = service.GetResources().ToList();

            foreach (var data in resourceContainerData.ResourcesData)
            {
                var resource = resources.FirstOrDefault(res => res.ID == data.Id);

                if (resource != null)
                    resource.Amount = data.Amount;
            }
        }
    }
}