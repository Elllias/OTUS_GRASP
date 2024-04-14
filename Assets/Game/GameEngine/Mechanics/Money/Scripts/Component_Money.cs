using Elementary;
using Game.GameEngine.Mechanics.Money.Scripts;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Money/Component «Money»")]
    public sealed class Component_Money : MonoBehaviour,
        IComponent_GetMoney,
        IComponent_EarnMoney,
        IComponent_SpendMoney
    {
        public int Money
        {
            get { return this.money.Current; }
        }

        [SerializeField]
        private MonoIntVariable money;

        public void EarnMoney(int range)
        {
            this.money.Current += range;
        }

        public void SpendMoney(int range)
        {
            this.money.Current -= range;
        }
    }
}