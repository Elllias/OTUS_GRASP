using UnityEngine;

namespace Windows.Examples
{
    public sealed class MyPopupSupplier : MonoWindowSupplier<MyPopupId, MonoWindow>
    {
        [SerializeField]
        private MyPopupFactory factory;

        protected override MonoWindow InstantiateFrame(MyPopupId key)
        {
            return this.factory.CreateWindow(key);
        }
    }
}