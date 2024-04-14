using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class Component_EquipType : IComponent_GetEqupType
    {
        public EquipType Type
        {
            get { return this.type; }
        }

        [SerializeField]
        private EquipType type;
    }
}