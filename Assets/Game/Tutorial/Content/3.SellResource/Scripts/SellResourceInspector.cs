using System;
using Game.Gameplay.Player;

namespace Game.Tutorial
{
    public sealed class SellResourceInspector
    {
        private SellResourceConfig config;

        private VendorInteractor sellInteractor;

        private Action callback;

        public void Construct(VendorInteractor sellInteractor, SellResourceConfig config)
        {
            this.sellInteractor = sellInteractor;
            this.config = config;
        }

        public void Inspect(Action callback)
        {
            this.callback = callback;
            this.sellInteractor.OnResourcesSold += this.OnResourcesSold;
        }

        private void OnResourcesSold(VendorSellResult result)
        {
            if (result.resourceType == this.config.targetResourceType)
            {
                this.CompleteQuest();
            }
        }

        private void CompleteQuest()
        {
            this.sellInteractor.OnResourcesSold -= this.OnResourcesSold;
            this.callback?.Invoke();
        }
    }
}