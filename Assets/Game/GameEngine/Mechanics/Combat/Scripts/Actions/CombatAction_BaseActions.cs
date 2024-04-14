using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class CombatAction_BaseActions : IAction<CombatOperation>
    {
        private readonly IAction[] actions;

        public CombatAction_BaseActions(IAction[] actions)
        {
            this.actions = actions;
        }

        public void Do(CombatOperation args)
        {
            for (int i = 0, count = this.actions.Length; i < count; i++)
            {
                var action = this.actions[i];
                action.Do();
            }
        }
    }
}