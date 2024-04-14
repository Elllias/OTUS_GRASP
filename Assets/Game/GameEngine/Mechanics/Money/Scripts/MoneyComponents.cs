namespace Game.GameEngine.Mechanics.Money.Scripts
{
    public interface IComponent_GetMoney
    {
        int Money { get; }
    }

    public interface IComponent_EarnMoney
    {
        void EarnMoney(int range);
    }

    public interface IComponent_SpendMoney
    {
        void SpendMoney(int range);
    }
}