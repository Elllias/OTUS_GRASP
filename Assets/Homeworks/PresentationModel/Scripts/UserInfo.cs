using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class UserInfo
    {
        public event Action<string> OnNameChanged;
        public event Action<string> OnDescriptionChanged;
        public event Action<Sprite> OnIconChanged; 

        [ShowInInspector, ReadOnly]
        public string Name { get; private set; }

        [ShowInInspector, ReadOnly]
        public string Description { get; private set; }

        [ShowInInspector, ReadOnly]
        public Sprite Icon { get; private set; }

        [Button]
        public void ChangeName(string name)
        {
            this.Name = name;
            this.OnNameChanged?.Invoke(name);
        }

        [Button]
        public void ChangeDescription(string description)
        {
            this.Description = description;
            this.OnDescriptionChanged?.Invoke(description);
        }

        [Button]
        public void ChangeIcon(Sprite icon)
        {
            this.Icon = icon;
            this.OnIconChanged?.Invoke(icon);
        }
    }
}