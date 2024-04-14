using UnityEngine;

namespace Windows.Examples
{
    public sealed class MyScreenSupplier : MonoWindowSupplier<MyScreenId, MonoWindow>
    {
        [SerializeField]
        private MyScreenFactory factory;
        
        protected override MonoWindow InstantiateFrame(MyScreenId key)
        {
            return this.factory.CreateWindow(key);
        }
    }
}