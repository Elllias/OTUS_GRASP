using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.MVO
{
    public sealed class MoneyStorage : MonoBehaviour
    {
        public event Action<int> OnMoneyChanged;

        public int Money
        {
            get { return this.money; }
        }

        [ReadOnly]
        [ShowInInspector]
        private int money;

        [Button]
        public void SetupMoney(int money)
        {
            this.money = money;
        }

        [Button]
        public void AddMoney(int range)
        {
            this.money += range;
            this.OnMoneyChanged?.Invoke(this.money);
        }

        [Button]
        public void SpendMoney(int range)
        {
            this.money -= range;
            this.OnMoneyChanged?.Invoke(this.money);
        }
    }
}