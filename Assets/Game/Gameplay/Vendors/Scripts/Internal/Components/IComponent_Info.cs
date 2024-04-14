using Game.GameEngine.GameResources;

namespace Game.Gameplay.Vendors
{
    public interface IComponent_Info
    {
        ResourceType ResourceType { get; }

        int PricePerOne { get; }
    }
}