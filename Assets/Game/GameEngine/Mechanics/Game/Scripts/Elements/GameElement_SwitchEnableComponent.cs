using System;
using Entities;
using GameSystem;
using Sirenix.OdinInspector;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class GameElement_SwitchEnableComponent : 
        IGameStartElement,
        IGameFinishElement
    {
        [ShowInInspector, ReadOnly]
        public IEntity target;
    
        public void Construct(IEntity target)
        {
            this.target = target;
        }

        void IGameStartElement.StartGame()
        {
            this.target.Get<IComponent_Enable>().SetEnable(true);
        }

        void IGameFinishElement.FinishGame()
        {
            this.target.Get<IComponent_Enable>().SetEnable(false);
        }
    }
}