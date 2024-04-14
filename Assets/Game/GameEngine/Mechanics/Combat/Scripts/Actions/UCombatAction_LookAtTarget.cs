using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Combat/Combat Action «Look At Target»")]
    public sealed class UCombatAction_LookAtTarget : UCombatAction
    {
        [SerializeField]
        public UTransformEngine lookAtScript;
        
        public override void Do(CombatOperation operation)
        {
            var targetPosition = operation.targetEntity.Get<IComponent_GetPosition>().Position;
            this.lookAtScript.LookAtPosition(targetPosition);
        }
    }
}