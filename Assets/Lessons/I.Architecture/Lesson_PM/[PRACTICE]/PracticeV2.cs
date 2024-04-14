using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    //Необходимо реализовать интерфейс для инвентаря с
    //оружиями с помощью паттерна Presentation Model
    //То есть интерфефс должен поддерживать возможность:
    //1. Добавлять и удалять N оружий
    //2. Хранить актуальное кол-во патронов для каждого оружия
    //3. При нажатии на оружие, будет выбираться текущее оружиеё
    
    public interface IWeapon
    {
        event Action<string> OnAmmoChanged;

        int Ammo { get; }
        int MaxAmmo { get; }

        Sprite Icon { get; }
    }

    public interface IWeaponManager
    {
        event Action<IWeapon> OnAdded;
        event Action<IWeapon> OnRemoved;
        
        void SelectWeapon(IWeapon weapon);
        IEnumerable<IWeapon> GetWeapons();
    }
}