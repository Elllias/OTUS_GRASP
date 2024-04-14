using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Destroy/Action «Base Actions»")]
    public sealed class UDestroyAction_BaseActions : UDestroyAction
    {
        [SerializeField]
        public MonoAction[] actions; 
    
        public override void Do(DestroyArgs args)
        {
            for (int i = 0, count = this.actions.Length; i < count; i++)
            {
                var action = this.actions[i];
                action.Do();
            }
        }
    }
}