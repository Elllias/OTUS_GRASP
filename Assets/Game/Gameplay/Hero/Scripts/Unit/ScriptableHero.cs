using Elementary;
using Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [CreateAssetMenu(
        fileName = "ScriptableHero",
        menuName = "Gameplay/Hero/New ScriptableHero"
    )]
    public sealed class ScriptableHero : ScriptableObject
    {
        [Title("Hit Points")]
        [SerializeField]
        public int baseHitPoints = 10;

        [Title("Speed")]
        [SerializeField]
        public float baseSpeed = 6;
        
        [SerializeField]
        public float baseSpeedMultiplier = 1;

        [Title("Harvest Resource")]
        [SerializeField]
        public float harvestDuration = 2.7f;
        
        [SerializeField]
        public ScriptableEntityCondition[] harvestConditions;
        
        [SerializeField]
        public ScriptableFloat harvestDistance;

        [Title("Combat")]
        [SerializeField]
        public int baseDamage = 1;
        
        [SerializeField]
        public float baseDamageMultiplier = 1;
        
        [SerializeField]
        public ScriptableEntityCondition[] combatConditions;

        [SerializeField]
        public ScriptableFloat combatDistance;

    }
}