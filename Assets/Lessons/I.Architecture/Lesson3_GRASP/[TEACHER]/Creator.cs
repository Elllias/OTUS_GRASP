// using System;
//
// namespace Lessons.Architecture.GRASP
// {
//    
//     
//     
//     public sealed class ProductPurchaser
//     {
//         private IMoneyTerminal moneyTerminal;
//
//         private UserWallet userWallet;
//         
//         public void Purchase(Product product, Action<Result> callback)
//         {
//             var transaction = new Transaction(product.id, this.moneyTerminal, this.userWallet);
//             transaction.Do(callback);
//         }
//     }
//
//     
//     
//     
//     
//     
//     var notification = new NotificationBuilder()
//         .SetChannel("my_channel")
//         .SetDuration(3600)
//         .SetTitle("My notification")
//         .SetMessage("This is an example notification")
//         .Build();
//     
//     
//     
//     
//  
//     


//
// public sealed class EnemySystem
// {
//     private EnemyCatalog catalog = new();
//     private EnemySpawner spawner = new();
//     private EnemyDestroyer destroyer = new();
//
//     public Enemy SpawnEnemy()
//     {
//         var enemyPref = this.catalog.RandomEnemy();
//         return this.spawner.Spawn(enemyPref);
//     }
//
//     public void DestroyEnemy(Enemy enemy)
//     {
//         this.destroyer.Destroy(enemy);
//     }
// }


//     
//     
//     
//     
//     
//     public sealed class PopupManager
//     {
//         private PopupFactory factory;
//         
//         public void ShowPopup(string popupName)
//         {
//             //Все зависимости разруливает фабрика:
//             var popup = this.factory.CreatePopup(popupName);
//             popup.Show();
//         }
//     }
//     
//     
// }



//
// public sealed class Player
// {
//     private int hitPoints;
//     private int damage;
//     private int speed;
//
//     public PlayerSnapshot MakeSnapshoot() {
//         return new PlayerSnapshot {
//             hitPoints = this.hitPoints,
//             damage = this.damage,
//             speed = this.speed
//         };
//     }
//
//     public void Restore(PlayerSnapshot snapshot) {
//         this.hitPoints = snapshot.hitPoints;
//         this.damage = snapshot.damage;
//         this.speed = snapshot.speed;
//     }
// }
//
// public sealed class PlayerSnapshot {
//     public int hitPoints;
//     public int damage;
//     public int speed;
// }


