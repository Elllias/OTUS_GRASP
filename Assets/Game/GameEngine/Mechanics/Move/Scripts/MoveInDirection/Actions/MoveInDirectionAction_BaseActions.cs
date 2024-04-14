using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public sealed class MoveInDirectionAction_BaseActions : IAction<Vector3>
    {
        private readonly IAction[] actions;

        public MoveInDirectionAction_BaseActions(params IAction[] actions)
        {
            this.actions = actions;
        }

        public void Do(Vector3 args)
        {
            for (int i = 0, count = this.actions.Length; i < count; i++)
            {
                var action = this.actions[i];
                action.Do();
            }
        }
    }
}