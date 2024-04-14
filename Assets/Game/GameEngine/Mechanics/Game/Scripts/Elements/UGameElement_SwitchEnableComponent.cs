using Entities;
using GameSystem;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Game/Game Element «Switch Enable Component»")]
    public sealed class UGameElement_SwitchEnableComponent : MonoBehaviour,
        IGameStartElement,
        IGameFinishElement
    {
        [SerializeField]
        public MonoEntity unit;

        void IGameStartElement.StartGame()
        {
            this.unit.Get<IComponent_Enable>().SetEnable(true);
        }

        void IGameFinishElement.FinishGame()
        {
            this.unit.Get<IComponent_Enable>().SetEnable(false);
        }
    }
}