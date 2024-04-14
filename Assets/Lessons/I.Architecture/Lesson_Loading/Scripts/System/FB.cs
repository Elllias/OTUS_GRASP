using System;
using UnityEngine;

namespace Lessons.Architecture.Loading
{
    //Facebook Plugin
    public class FB
    {
        private const bool success = true;

        public static void Init(Action onSuccess, Action<string> onError)
        {
            if (FB.success)
            {
                Debug.Log("<color=blue>Init Facebook</color>");
                onSuccess?.Invoke();
            }
            else
            {
                onError?.Invoke("Facebook init failed!");
            }
        }
    }
}