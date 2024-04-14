using Game.GameEngine.GameResources;
using UnityEngine;

namespace Game.Gameplay.Player
{
    [CreateAssetMenu(
        fileName = "ResourceStorageConfig",
        menuName = "Gameplay/Player/New ResourceStorageConfig"
    )]
    public sealed class ResourceStorageConfig : ScriptableObject
    {
        public ResourceData[] InitialResources
        {
            get { return this.initialResources; }
        }

        [SerializeField]
        private ResourceData[] initialResources;

        public static ResourceStorageConfig LoadAsset()
        {
            return Resources.Load<ResourceStorageConfig>(nameof(ResourceStorageConfig));
        }
    }
}