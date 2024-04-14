// using System;
// using System.Collections.Generic;
//
// public interface IAnalyicsManager
// {
//     void LogEvent(string key, params AnalyticsParam[] parameters);
// }
//
// public struct AnalyticsParam
// {
//     public string name;
//     public string value;
//
//     public AnalyticsParam(string name, string value)
//     {
//         this.name = name;
//         this.value = value;
//     }
// }
//
//
// public interface IMoneyBank
// {
//     int Money { get; }
//
//     void SpendMoney(int range);
//     void EarnMoney(int range);
// }
//
// public sealed class MoneyBank : IMoneyBank
// {
//     public int Money { get; private set; }
//
//     public void SpendMoney(int range) => this.Money -= range;
//     public void EarnMoney(int range) => this.Money += range;
// }
//
// public sealed class Product
// {
//     public string id;
//     public string type;
//     public int price;
// }
//
// public interface IProductBuyer
// {
//     event Action<Product> OnProductBought;
//
//     bool CanBuyProduct(Product product);
//     void BuyProduct(Product product);
// }
//
//
// public sealed class MoneyBankDecorator : IMoneyBank
// {
//     private readonly IMoneyBank moneyBank;
//
//     public int Money => this.moneyBank.Money;
//     public int PreviousMoney { get; private set; }
//     public IReadOnlyList<int> Transactions => this.transactions;
//
//     private readonly List<int> transactions = new List<int>();
//
//     public MoneyBankDecorator(IMoneyBank moneyBank)
//     {
//         this.moneyBank = moneyBank;
//         this.PreviousMoney = moneyBank.Money;
//     }
//
//     public void SpendMoney(int range)
//     {
//         this.CacheMoney(-range);
//         this.moneyBank.SpendMoney(range);
//     }
//
//     public void EarnMoney(int range)
//     {
//         this.CacheMoney(range);
//         this.moneyBank.EarnMoney(range);
//     }
//
//     private void CacheMoney(int range)
//     {
//         this.PreviousMoney = this.Money;
//         this.transactions.Add(range);
//     }
// }
//
// public sealed class ProductAnalyticsTracker : IInitializable, IDisposable
// {
//     private readonly IProductBuyer productBuyer;
//     private readonly MoneyBankDecorator moneyBank;
//     private readonly IAnalyicsManager analyicsManager;
//
//     public ProductAnalyticsTracker(
//         IProductBuyer productBuyer,
//         MoneyBankDecorator moneyBank,
//         IAnalyicsManager analyicsManager
//     )
//     {
//         this.productBuyer = productBuyer;
//         this.moneyBank = moneyBank;
//         this.analyicsManager = analyicsManager;
//     }
//
//     void IInitializable.Initialize()
//     {
//         this.productBuyer.OnProductBought += this.OnProductBought;
//     }
//
//     void IDisposable.Dispose()
//     {
//         this.productBuyer.OnProductBought -= this.OnProductBought;
//     }
//
//     private void OnProductBought(Product product)
//     {
//         this.analyicsManager.LogEvent("product_bought",
//             new AnalyticsParam("product_id", product.id),
//             new AnalyticsParam("product_type", product.type),
//             new AnalyticsParam("previous_money", this.moneyBank.PreviousMoney.ToString()),
//             new AnalyticsParam("current_money", this.moneyBank.Money.ToString())
//         );
//     }
// }
//
// public interface IInitializable
// {
//     void Initialize();
// }