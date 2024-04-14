using Entities;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [CreateAssetMenu(
        fileName = "Condition «Can Take Damage»",
        menuName = "GameEngine/Mechanics/Take Damage/New Entity Condition «Can Take Damage»"
    )]
    public sealed class SEntityCondition_CanTakeDamage :  ScriptableEntityCondition
    {
        public override bool IsTrue(IEntity entity)
        {
            return entity.TryGet(out IComponent_TakeDamage _);
        }
    }
}