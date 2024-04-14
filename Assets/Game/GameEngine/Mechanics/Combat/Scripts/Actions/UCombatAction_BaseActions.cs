using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Combat/Combat Action «Base Actions»")]
    public sealed class UCombatAction_BaseActions : UCombatAction
    {
        [SerializeField]
        public MonoAction[] actions;
    
        public override void Do(CombatOperation args)
        {
            for (int i = 0, count = this.actions.Length; i < count; i++)
            {
                var action = this.actions[i];
                action.Do();
            }
        }
    }
}