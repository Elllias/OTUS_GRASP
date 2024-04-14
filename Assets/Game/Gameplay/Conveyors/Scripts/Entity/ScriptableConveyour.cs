using Game.GameEngine;
using Game.GameEngine.GameResources;
using UnityEngine;

namespace Game.Gameplay.Conveyors
{
    [CreateAssetMenu(
        fileName = "ScriptableConveyor",
        menuName = "Gameplay/Conveyors/New ScriptableConveyor"
    )]
    public sealed class ScriptableConveyour : ScriptableObject
    {
        [SerializeField]
        public string id;

        [SerializeField]
        public ObjectType objectType = ObjectType.CONVEYOR;
        
        [Header("Load Zone")]
        [SerializeField]
        public ResourceType inputResourceType;

        [SerializeField]
        public int inputCapacity;

        [Header("Unload Zone")]
        [SerializeField]
        public ResourceType outputResourceType;

        [SerializeField]
        public int outputCapacity;

        [Header("Work")]
        [SerializeField]
        public float workTime;
    }
}