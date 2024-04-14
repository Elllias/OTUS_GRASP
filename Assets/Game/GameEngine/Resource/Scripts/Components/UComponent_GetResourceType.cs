using UnityEngine;

namespace Game.GameEngine.GameResources
{
    [AddComponentMenu("GameEngine/GameResources/Component «Get Resource Type»")]
    public sealed class UComponent_GetResourceType : MonoBehaviour, IComponent_GetResourceType
    {
        public ResourceType Type
        {
            get { return this.type; }
        }

        [SerializeField]
        private ResourceType type;
    }
}