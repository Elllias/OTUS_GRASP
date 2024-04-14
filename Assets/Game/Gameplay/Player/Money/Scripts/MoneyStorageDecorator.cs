using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Player
{
    [AddComponentMenu("Gameplay/Player Money Storage Decorator")]
    public sealed class MoneyStorageDecorator : MonoBehaviour, IGameConstructElement
    {
        private MoneyStorage storage;
        private MoneyPanel view;
        
        //TODO ANIMATORS...

        public void EarnMoneySimple(int money)
        {
            this.storage.EarnMoney(money);
            this.view.IncrementMoney(money);
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.storage = context.GetService<MoneyStorage>();
            this.view = context.GetService<MoneyPanel>();
        }
    }
}