using Entities;

namespace Game.GameEngine.AI
{
    public sealed class CommandArgs_AttackTarget
    {
        public readonly IEntity target;

        public CommandArgs_AttackTarget(IEntity target)
        {
            this.target = target;
        }
    }
}