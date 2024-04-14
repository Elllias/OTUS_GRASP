//
// namespace Lessons.Architecture.GRASP
// {
//
     // public sealed class RewardManager
     // {
     //     private Hero hero;
     //     private RewardConfig config;
     //     private PlayerMoney playerMoney;
     //
     //     public void Enable() {
     //         this.hero.OnTargetDestroyed += this.OnEnemyDestroyed;
     //     }
     //
     //     public void Disable() {
     //         this.hero.OnTargetDestroyed -= this.OnEnemyDestroyed;
     //     }
     //
     //     private void OnEnemyDestroyed(Enemy enemy) {
     //         int rewardCoef = enemy.RewardCoef;
     //         int moneyReward = UnityEngine.Random.Range(config.minReward, config.maxReward) * rewardCoef;
     //         this.playerMoney.EarnMoney(moneyReward);
     //     }
     // }
//
//     public sealed class GameWinObserver
//     {
//         private GameSystem gameSystem;
//         private WinPopup winPopup;
//         
//         public void Enable() {
//             this.gameSystem.OnGameWin += this.winPopup.Show;
//         }
//
//         public void Disable() {
//             this.gameSystem.OnGameWin -= this.winPopup.Show;
//         }
//     }
//     
//     
//     
// }