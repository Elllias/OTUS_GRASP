using System;
using UnityEngine;

namespace Windows.Examples
{
    public sealed class MyScreenFactory : MonoWindowFactory<MyScreenId, MonoWindow>
    {
        [SerializeField]
        private ScreenInfo[] screens;

        protected override MonoWindow GetPrefab(MyScreenId key)
        {
            foreach (var frame in this.screens)
            {
                if (frame.id == key)
                {
                    return frame.prefab;
                }
            }

            throw new Exception($"Frame {key} is not found!");
        }


        [Serializable]
        private sealed class ScreenInfo
        {
            [SerializeField]
            public MyScreenId id;

            [SerializeField]
            public MonoWindow prefab;
        }
    }
}