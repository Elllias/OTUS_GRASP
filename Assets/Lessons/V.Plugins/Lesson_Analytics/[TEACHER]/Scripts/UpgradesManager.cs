// using System;
// using Game;
// using Game.Gameplay.Player;
//
// // ReSharper disable UnusedMember.Local
// // ReSharper disable UnusedParameter.Global
// #pragma warning disable CS0169
//
// // ReSharper disable UnusedMember.Global
// // ReSharper disable UnusedType.Global
// #pragma warning disable CS0649
//
// namespace Lessons.PRESENTATION.ANALYTICS
// {
//     // public sealed class UpgradesManager 
//     // {
//     //     private IMoneyBank moneyBank;
//     //
//     //     public void LevelUp(IHeroUpgrade upgrade) {}
//     //
//     //     private void LogAnalyticsEvent(IHeroUpgrade upgrade) 
//     //     {
//     //         AppMetrica.Instance.ReportEvent("buy_upgrade", new Dictionary<string, object> {
//     //             {"upgrade_Id", upgrade.Id},
//     //             {"level", upgrade.Level}});
//     //         
//     //         FirebaseAnalytics.LogEvent("buy_upgrade",
//     //             new Parameter("upgrade_Id", upgrade.Id),
//     //             new Parameter("level", upgrade.Level));
//     //         
//     //         GameAnalytics.NewDesignEvent("buy_upgrade", new Dictionary<string, object> {
//     //             {"upgrade_Id", upgrade.Id},
//     //             {"level", upgrade.Level}});
//     //     }
//     // }
//
//
//     public sealed class UpgradesManager
//     {
//         public event Action<IHeroUpgrade> OnUpgradeLevelUp; 
//
//         private MoneyStorage moneyStorage;
//
//         public void LevelUp(IHeroUpgrade upgrade)
//         {
//             this.moneyStorage.SpendMoney(upgrade.NextPrice);
//             upgrade.IncrementLevel();
//             this.OnUpgradeLevelUp?.Invoke(upgrade);
//         }
//     }
//     
//     
//     //
//     // public sealed class UpgradesAnalyticsTracker
//     // {
//     //     private UpgradesManager manager;
//     //     
//     //     private IMoneyBank moneyBank;
//     //
//     //     private void Init()
//     //     {
//     //         this.manager.OnUpgradeLevelUp += this.OnLevelUpUpgrade;
//     //     }
//     //
//     //     private void OnLevelUpUpgrade(IHeroUpgrade upgrade)
//     //     {
//     //         AnalyticsManager.LogEvent("buy_upgrade",
//     //             new AnalyticsParameter("upgrade_Id", upgrade.Id),
//     //             new AnalyticsParameter("level", upgrade.Level),
//     //             new AnalyticsParameter("moneyBefore", moneyBefore), //???
//     //             new AnalyticsParameter("moneyAfter", this.moneyBank.Money),
//     //             new AnalyticsParameter("lifetime", UserManager.GetLifetime())
//     //         );
//     //     }
//     // }
//
//     
//     
//     //
//     //
//     //
//     //
//     // public sealed class UserManager
//     // {
//     //     public static int  GetLifetime()
//     //     {
//     //         
//     //     }
//     // }
// }
// //