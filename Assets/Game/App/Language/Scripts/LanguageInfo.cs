using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    public sealed class LanguageInfo
    {
        [SerializeField]
        public SystemLanguage language;
    
        [Space]
        [SerializeField]
        public string title;
    }
}