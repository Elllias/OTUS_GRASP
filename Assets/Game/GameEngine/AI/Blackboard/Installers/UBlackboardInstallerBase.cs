using AI.Blackboards;
using GameSystem;
using Sirenix.OdinInspector;

namespace Game.Gameplay.AI
{
    public abstract class UBlackboardInstallerBase : SerializedMonoBehaviour, IBlackboardInjective, IGameConstructElement
    {
        public IBlackboard Blackboard { private get; set; }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.Install(this.Blackboard, context);
        }

        protected abstract void Install(IBlackboard blackboard, GameContext context);
    }
}