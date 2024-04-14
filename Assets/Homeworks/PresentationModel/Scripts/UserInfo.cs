using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class UserInfo : MonoBehaviour
    {
        public event Action<string> OnNameChanged;
        public event Action<string> OnDescriptionChanged;
        public event Action<Sprite> OnIconChanged;

        [ShowInInspector]public string Name /*{ get; private set; }*/;

        [ShowInInspector]
        public string Description /*{ get; private set; }*/;

        [ShowInInspector]
        public Sprite Icon /*{ get; private set; }*/;

        [Button]
        public void ChangeName(string name)
        {
            Name = name;
            OnNameChanged?.Invoke(name);
        }

        [Button]
        public void ChangeDescription(string description)
        {
            Description = description;
            OnDescriptionChanged?.Invoke(description);
        }

        [Button]
        public void ChangeIcon(Sprite icon)
        {
            Icon = icon;
            OnIconChanged?.Invoke(icon);
        }
    }
}