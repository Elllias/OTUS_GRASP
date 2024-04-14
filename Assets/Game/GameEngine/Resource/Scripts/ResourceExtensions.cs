using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Game.GameEngine.GameResources
{
    public static class ResourceExtensions
    {
        public static string SerializeToJson(IResourceSource resourceDictionary)
        {
            var resources = new List<ResourceData>();
            resourceDictionary.GetAllNonAlloc(resources);
            return SerializeToJson(resources);
        }

        public static string SerializeToJson(IEnumerable<ResourceData> resources)
        {
            var result = new List<ResourceDataSerialized>();
            foreach (var resource in resources)
            {
                var type = resource.type.ToString();
                var amount = resource.amount;
                var serializedData = new ResourceDataSerialized(type, amount);
                result.Add(serializedData);
            }

            return JsonConvert.SerializeObject(result);
        }

        public static ResourceData[] ToDataArray(this Dictionary<ResourceType, int> resources)
        {
            var count = resources.Count;
            var result = new ResourceData[count];
            var i = 0;
            foreach (var pair in resources)
            {
                var resourceType = pair.Key;
                var amount = pair.Value;
                result[i++] = new ResourceData(resourceType, amount);
            }

            return result;
        }

        public static Dictionary<ResourceType, int> ToDictionary(this ResourceData[] resources)
        {
            var count = resources.Length;
            var result = new Dictionary<ResourceType, int>(count);
            for (var i = 0; i < count; i++)
            {
                var data = resources[i];
                result[data.type] = data.amount;
            }

            return result;
        }
        
        public static int FindAmount(this ResourceData[] resources, ResourceType type)
        {
            for (int i = 0, count = resources.Length; i < count; i++)
            {
                var resource = resources[i];
                if (resource.type == type)
                {
                    return resource.amount;
                }
            }

            throw new Exception("Resource is not found!");
        }
        
        public static ResourceData[] Diff(this ResourceData[] resources, IResourceSource dictionary)
        {
            var count = resources.Length;
            var result = new ResourceData[count];
            
            for (var i = 0; i < count; i++)
            {
                var requiredResource = resources[i];
                var amount = requiredResource.amount;
                var type = requiredResource.type;
                
                var diff = amount - dictionary[type];
                result[i] = new ResourceData(type, diff);
            }

            return result;
        }
        
        public static int ExtractAll(this IResourceSource it, ResourceType type)
        {
            var count = it[type];
            it.Minus(type, count);
            return count;
        }

        public static ResourceData[] ExtractAll(this IResourceSource it)
        {
            var result = it.GetAll();
            for (int i = 0, count = result.Length; i < count; i++)
            {
                var resource = result[i];
                it.Minus(resource.type, resource.amount);
            }

            return result;
        }

        public static void Minus(this IResourceSource it, ResourceData resource)
        {
            it.Minus(resource.type, resource.amount);
        }

        public static void Minus(this IResourceSource it, ResourceData[] resources)
        {
            for (int i = 0, count = resources.Length; i < count; i++)
            {
                var resource = resources[i];
                it.Minus(resource.type, resource.amount);
            }
        }

        public static bool Exists(this IResourceSource it, ResourceData requiredResource)
        {
            return it.Exists(requiredResource.type, requiredResource.amount);
        }

        public static bool Exists(this IResourceSource it, ResourceData[] requiredResources)
        {
            for (int i = 0, count = requiredResources.Length; i < count; i++)
            {
                var requiredResource = requiredResources[i];
                if (!it.Exists(requiredResource))
                {
                    return false;
                }
            }

            return true;
        }
    }
}