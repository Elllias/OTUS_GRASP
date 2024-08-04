using TechTree;

namespace Money
{
    public sealed class MoneyStorage : IMoneyStorage
    {
        public int Money { get; private set; }

        public MoneyStorage(int money)
        {
            Money = money;
        }

        public bool CanSpend(int range)
        {
            return Money >= range;
        }

        public void Spend(int range)
        {
            if (CanSpend(range))
            {
                Money -= range;
            }
        }
    }
}