using Game.Gameplay.Player;
using Newtonsoft.Json;
using UnityEngine;

namespace Lessons.Architecture.SaveLoad
{
    //Project 
    public sealed class MoneySaveLoader : SaveLoader<MoneyData, MoneyStorage>
    {
        protected override void SetupData(MoneyStorage moneyStorage, MoneyData data)
        {
            moneyStorage.SetupMoney(data.money);
            Debug.Log($"<color=green>Money loaded: {data.money}!</color>");
        }

        protected override MoneyData ConvertToData(MoneyStorage moneyStorage)
        {
            Debug.Log($"<color=green>Money saved: {moneyStorage.Money}!</color>");
            return new MoneyData
            {
                money = moneyStorage.Money
            };
        }
    }
}