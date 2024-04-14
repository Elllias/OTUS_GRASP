using System;
using Entities;
using GameSystem;
using Sirenix.OdinInspector;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class GameElement_SwitchEnableComponents : 
        IGameStartElement,
        IGameFinishElement
    {
        [ShowInInspector, ReadOnly]
        public IEntity[] targets;
    
        public void Construct(params IEntity[] targets)
        {
            this.targets = targets;
        }

        void IGameStartElement.StartGame()
        {
            for (int i = 0, count = this.targets.Length; i < count; i++)
            {
                var target = this.targets[i];
                target.Get<IComponent_Enable>().SetEnable(true);
            }
        }

        void IGameFinishElement.FinishGame()
        {
            for (int i = 0, count = this.targets.Length; i < count; i++)
            {
                var target = this.targets[i];
                target.Get<IComponent_Enable>().SetEnable(false);
            }
        }
    }
}