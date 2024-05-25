using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class CharacterStat : MonoBehaviour
    {
        public event Action<int> OnValueChanged; 

        [ShowInInspector]
        public string Name;

        [ShowInInspector]
        public int Value;

        [Button]
        public void ChangeValue(int value)
        {
            Value = value;
            OnValueChanged?.Invoke(value);
        }
    }
}