using System;
using System.Threading.Tasks;
using Windows;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.GameEngine
{
    [CreateAssetMenu(
        fileName = "PopupCatalog",
        menuName = "GameEngine/New PopupCatalog"
    )]
    public sealed class PopupCatalog : ScriptableObject
    {
        [Space]
        [SerializeField]
        private PopupInfo[] popups = Array.Empty<PopupInfo>();

        public async Task LoadAssets()
        {
            var count = this.popups.Length;
            var tasks = new Task<GameObject>[count];
            
            for (var i = 0; i < count; i++)
            {
                var info = this.popups[i];
                var handle = info.addressable.LoadAssetAsync<GameObject>();
                tasks[i] = handle.Task;
            }

            var prefabs = await Task.WhenAll(tasks);
            for (var i = 0; i < count; i++)
            {
                var info = this.popups[i];
                var prefab = prefabs[i];
                info.prefab = prefab.GetComponent<MonoWindow>();
            }
        }

        public MonoWindow GetPrefab(PopupName name)
        {
            for (int i = 0, count = this.popups.Length; i < count; i++)
            {
                var info = this.popups[i];
                if (info.name == name)
                {
                    return info.prefab;
                }
            }
            
            throw new Exception($"Prefab {name} is not found!");
        }

        [Serializable]
        private sealed class PopupInfo
        {
            [SerializeField]
            public PopupName name;
            
            [SerializeField]
            public AssetReference addressable;

            [NonSerialized]
            public MonoWindow prefab;
        }
    }
}