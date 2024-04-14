using Entities;

namespace Game.GameEngine.AI
{
    public sealed class CommandArgs_HarvestTarget
    {
        public readonly IEntity target;

        public CommandArgs_HarvestTarget(IEntity target)
        {
            this.target = target;
        }
    }
}