using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterStat : MonoBehaviour
    {
        public event Action<int> OnValueChanged; 

        [ShowInInspector]
        public string Name /*{ get; private set; }*/;

        [ShowInInspector]
        public int Value /*{ get; private set; }*/;

        [Button]
        public void ChangeValue(int value)
        {
            Value = value;
            OnValueChanged?.Invoke(value);
        }
    }
}