using Entities;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [CreateAssetMenu(
        fileName = "ScriptableEnemyWarriorAI",
        menuName = "Gameplay/Enemies/New ScriptableEnemyWarriorAI"
    )]
    public sealed class ScriptableEnemyWarriorAI : ScriptableObject 
    {
        public const string UNIT_KEY = "Unit";

        public const string TARGET_KEY = "Target";

        public const string SURFACE_KEY = "Surface";

        public const string WAYPOINTS_KEY = "Waypoints";

        public const string TARGET_POSITION_KEY = "TargetPosition";
    
        [SerializeField]
        public float meleeStoppingDistance = 1.2f;

        [SerializeField]
        public float pointStoppingDistance = 0.15f;

        [SerializeField]
        public float patrolWaitTime = 0.25f;

        [Space]
        [SerializeField]
        public ScriptableEntityCondition[] detectTargetConditions;
    }
}