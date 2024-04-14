using System;
using System.Collections.Generic;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.MetaGame.Upgrades
{
    public sealed class UpgradeTest : MonoBehaviour, IGameElementGroup
    {
        [SerializeField]
        private UpgradeConfig config;

        [ShowInInspector]
        private Upgrade upgrade;
        
        private void Awake()
        {
            this.upgrade = this.config.InstantiateUpgrade();
        }

        IEnumerable<IGameElement> IGameElementGroup.GetElements()
        {
            if (this.upgrade is IGameElement gameUpgrade)
            {
                yield return gameUpgrade;                
            }
        }
    }
}