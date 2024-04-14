using Game.GameEngine.GameResources;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_MoneyPrice
    {
        int Price { get; }
    }

    public interface IComponent_ResourcePrice
    {
        ResourceData[] GetPrice();
    }
}