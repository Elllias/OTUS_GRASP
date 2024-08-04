using Sirenix.OdinInspector;
using TechTree;
using UnityEngine;
using Zenject;

namespace Money
{
    public sealed class MoneyDebug : MonoBehaviour
    {
        private IMoneyStorage _moneyStorage;

        [Inject]
        public void Construct(IMoneyStorage moneyStorage)
        {
            _moneyStorage = moneyStorage;
        }

        [Button]
        public int GetMoney()
        {
            return _moneyStorage.Money;
        }
    }
}