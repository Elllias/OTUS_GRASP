using UnityEngine;

namespace Windows.Examples
{
    public sealed class MyPopupManager : MonoPopupManager<MyPopupId>
    {
        protected override IWindowSupplier<MyPopupId, MonoWindow> Supplier
        {
            get { return this.supplier; }
        }

        [SerializeField]
        private MyPopupSupplier supplier;
    }
}