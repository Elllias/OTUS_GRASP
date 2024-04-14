using System;

namespace Game.GameEngine.InventorySystem
{
    public interface IComponent_Stackable
    {
        event Action<int> OnValueChanged;

        int Value { get; set; }
        int Size { get; }
        bool IsFull { get; }
    }
}