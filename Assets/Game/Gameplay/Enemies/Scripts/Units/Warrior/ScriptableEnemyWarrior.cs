using Elementary;
using Entities;
using Game.GameEngine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    [CreateAssetMenu(
        fileName = "ScriptableEnemyWarrior",
        menuName = "Gameplay/Enemies/New ScriptableEnemyWarrior"
    )]
    public sealed class ScriptableEnemyWarrior : ScriptableObject
    {
        [SerializeField]
        public int hitPoints = 3;
        
        [SerializeField]
        public float moveSpeed = 5;

        [SerializeField]
        public int damage = 1;
        
        [Space]
        [SerializeField]
        public ScriptableFloat minCombatDistance;

        [SerializeField]
        public ScriptableEntityCondition[] combatConditions = new ScriptableEntityCondition[0];
        
        [Title("Meta")]
        [SerializeField]
        public string enemyName = "Ork";

        [SerializeField]
        public ObjectType objectType = ObjectType.ENEMY;

    }
}