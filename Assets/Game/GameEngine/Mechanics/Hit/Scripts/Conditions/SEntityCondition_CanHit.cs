using Entities;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [CreateAssetMenu(
        fileName = "Condition «Can Hit»",
        menuName = "GameEngine/Mechanics/Hit Points/New Entity Condition «Can Hit»"
    )]
    public sealed class SEntityCondition_CanHit : ScriptableEntityCondition
    {
        public override bool IsTrue(IEntity entity)
        {
            return entity.TryGet(out IComponent_Hit _);
        }
    }
}