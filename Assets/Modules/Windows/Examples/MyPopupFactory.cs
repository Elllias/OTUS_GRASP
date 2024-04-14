using System;
using Windows;
using UnityEngine;

namespace Windows.Examples
{
    public sealed class MyPopupFactory : MonoWindowFactory<MyPopupId, MonoWindow>
    {
        [SerializeField]
        private PopupInfo[] popups;

        protected override MonoWindow GetPrefab(MyPopupId key)
        {
            foreach (var info in this.popups)
            {
                if (info.id == key)
                {
                    return info.prefab;
                }
            }

            throw new Exception($"Frame {key} is not found!");
        }

        [Serializable]
        private sealed class PopupInfo
        {
            [SerializeField]
            public MyPopupId id;

            [SerializeField]
            public MonoWindow prefab;
        }
    }
}