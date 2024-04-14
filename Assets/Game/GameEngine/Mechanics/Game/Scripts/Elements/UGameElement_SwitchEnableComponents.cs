using Entities;
using GameSystem;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Game/Game Element «Switch Enable Components»")]
    public sealed class UGameElement_SwitchEnableComponents : MonoBehaviour,
        IGameStartElement,
        IGameFinishElement
    {
        [SerializeField]
        public MonoEntity[] units;

        void IGameStartElement.StartGame()
        {
            this.EnableUnits(true);
        }

        void IGameFinishElement.FinishGame()
        {
            this.EnableUnits(false);
        }

        private void EnableUnits(bool isEnable)
        {
            for (int i = 0, count = this.units.Length; i < count; i++)
            {
                var unit = this.units[i];
                unit.Get<IComponent_Enable>().SetEnable(isEnable);
            }
        }
    }
}