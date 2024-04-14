using System;
using UnityEngine;

namespace Game.App
{
    [Serializable]
    public struct AudioSettingsData
    {
        [SerializeField]
        public float musicVolume;

        [SerializeField]
        public float soundVolume;
    }
}