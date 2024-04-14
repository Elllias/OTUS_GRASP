using Game.GameEngine;
using Game.GameEngine.GameResources;
using UnityEngine;

namespace Game.Gameplay.Vendors
{
    [CreateAssetMenu(
        fileName = "ScriptableVendor",
        menuName = "Gameplay/Vendors/New ScriptableVendor"
    )]
    public sealed class ScriptableVendor : ScriptableObject
    {
        [SerializeField]
        public ResourceType resourceType;
        
        [SerializeField]
        public int pricePerOne = 10;

        [Space]
        [SerializeField]
        public ObjectType objectType = ObjectType.VENDOR;
    }
}