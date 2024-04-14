using Entities;
using Game.GameEngine.Mechanics;

namespace Lessons.MetaGame.Inventory
{
    public sealed class InventoryEffectsApplier : IInventoryObserver
    {
        private readonly IEntity hero;

        public InventoryEffectsApplier(IEntity hero)
        {
            this.hero = hero;
        }

        void IInventoryObserver.OnItemAdded(InventoryItem item)
        {
            if (IsEffectible(item))
            {
                var effect = GetEffect(item);
                this.hero.Get<IComponent_Effector>().Apply(effect);
            }
        }

        void IInventoryObserver.OnItemRemoved(InventoryItem item)
        {
            if (IsEffectible(item))
            {
                var effect = GetEffect(item);
                this.hero.Get<IComponent_Effector>().Discard(effect);
            }
        }

        private static IEffect GetEffect(InventoryItem item)
        {
            return item.GetComponent<IComponent_GetEffect>().Effect;
        }

        private static bool IsEffectible(InventoryItem item)
        {
            return item.Flags.HasFlag(InventoryItemFlags.EFFECTIBLE);
        }
    }
}