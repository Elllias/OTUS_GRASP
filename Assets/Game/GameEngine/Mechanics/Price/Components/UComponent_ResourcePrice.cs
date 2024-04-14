using Game.GameEngine.GameResources;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Price/Component «Resource Price»")]
    public sealed class UComponent_ResourcePrice : MonoBehaviour, IComponent_ResourcePrice
    {
        [SerializeField]
        private ResourceData[] price;
        
        public ResourceData[] GetPrice()
        {
            return this.price;
        }
    }
}