using Game.GameEngine;
using Game.GameEngine.GameResources;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Gameplay.ResourceObjects
{
    [CreateAssetMenu(
        fileName = "ScriptableResource",
        menuName = "Gameplay/Resources/New ScriptableResource"
    )]
    public sealed class ScriptableResource : ScriptableObject
    {
        [FormerlySerializedAs("type")]
        [SerializeField]
        public ResourceType resourceType;

        [FormerlySerializedAs("count")]
        [SerializeField]
        public int resourceAmount;

        [Space]
        [SerializeField]
        public float respawnTime = 4.0f;

        [Space]
        [SerializeField]
        public ObjectType objectType = ObjectType.RESOURCE_OBJECT;
    }
}