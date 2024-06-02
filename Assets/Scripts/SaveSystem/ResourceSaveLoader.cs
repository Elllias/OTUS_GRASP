using System.Collections.Generic;
using System.IO;
using System.Linq;
using GameEngine;
using Newtonsoft.Json;
using SaveSystem.Data;
using SaveSystem.Interfaces;
using SaveSystem.Utils;
using UnityEngine;

namespace SaveSystem
{
    internal sealed class ResourceSaveLoader : ISaveLoader<ResourceService>
    {
        private const string RESOURCES_FILE_NAME = "Resources.txt";

        private readonly string _savePath = Application.persistentDataPath;

        public void Save(ResourceService service)
        {
            var resources = ResourcesToData(service.GetResources());
            var json = Encryptor.Encrypt(JsonConvert.SerializeObject(resources));

            var path = Path.Combine(_savePath, RESOURCES_FILE_NAME);

            File.WriteAllText(path, json);
        }

        public void Load(ResourceService service)
        {
            var path = Path.Combine(_savePath, RESOURCES_FILE_NAME);
            var json = Encryptor.Decrypt(File.ReadAllText(path));

            var resourcesData = JsonConvert.DeserializeObject<IEnumerable<ResourceData>>(json);
            var resources = service.GetResources().ToList();

            foreach (var data in resourcesData)
            {
                var resource = resources.FirstOrDefault(res => res.ID == data.Id);

                if (resource != null)
                    resource.Amount = data.Amount;
            }
        }

        private IEnumerable<ResourceData> ResourcesToData(IEnumerable<Resource> resources)
        {
            var resourcesData = new List<ResourceData>();

            foreach (var resource in resources)
            {
                var data = new ResourceData
                {
                    Id = resource.ID,
                    Amount = resource.Amount
                };

                resourcesData.Add(data);
            }

            return resourcesData;
        }
    }
}