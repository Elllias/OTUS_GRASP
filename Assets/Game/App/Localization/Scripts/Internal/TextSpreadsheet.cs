using System;
using System.Collections;
using System.Collections.Generic;
using LocalizationModule;
using UnityEngine;

namespace Game.Localization
{
    [Serializable]
    public struct TextSpreadsheet
    {
        [SerializeField]
        public Page[] pages;
        
        [Serializable]
        public struct Page
        {
            [SerializeField]
            public string name;

            [SerializeField]
            public TextEntity[] entities;
        }
    }
}