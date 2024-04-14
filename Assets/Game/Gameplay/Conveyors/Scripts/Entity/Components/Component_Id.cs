using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.Gameplay.Conveyors
{
    public sealed class Component_Id : IComponent_GetId
    {
        public string Id { get; }

        public Component_Id(string id)
        {
            this.Id = id;
        }
    }
}