using Elementary;
using Declarative;

namespace Game.Gameplay.Conveyors
{
    public sealed class ZoneVisualAdapter :
        IAwakeListener,
        IEnableListener,
        IDisableListener
    {
        private IVariableLimited<int> storage;

        private ZoneVisual visualZone;

        public void Construct(IVariableLimited<int> storage, ZoneVisual visualZone)
        {
            this.storage = storage;
            this.visualZone = visualZone;
        }

        void IAwakeListener.Awake()
        {
            this.visualZone.SetupItems(this.storage.Current);
        }

        void IEnableListener.OnEnable()
        {
            this.storage.OnValueChanged += this.OnItemsChanged;
        }

        void IDisableListener.OnDisable()
        {
            this.storage.OnValueChanged -= this.OnItemsChanged;
        }

        private void OnItemsChanged(int count)
        {
            this.visualZone.SetupItems(count);
        }
    }
}