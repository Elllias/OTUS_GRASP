// // namespace Lessons.Architecture.GRASP
// // {
// //     public sealed class QuestManager : MonoBehaviour,
// //     {
// //         public event Action<Quest> OnQuestTaken;
// //         public event Action<Quest> OnQuestStarted;
// //         public event Action<Quest> OnQuestCompleted;
// //         public event Action<Quest> OnQuestRewardReceived;
// //
// //         public bool QuestExists => this.Quest != null;
// //         public Quest Quest { get; private set; }
// //
// //         private QuestSelector selector;
// //         private QuestFactory factory;
// //
// //         private MoneyStorage moneyStorage;
// //         private MoneyPanel moneyPanel;
// //
// //         public void TakeNewQuest() {
// //             if (!this.CanTakeNewQuest()) {
// //                 throw new Exception("Can not take current quest!");
// //             }
// //
// //             QuestConfig questConfig = this.selector.SelectRandomQuest();
// //             Quest quest = this.factory.CreateQuest(questConfig);
// //
// //             this.Quest = quest;
// //             this.Quest.OnCompleted += this.OnCompleteQuest;
// //
// //             this.Quest.Start();
// //             this.OnQuestStarted?.Invoke(quest);
// //             this.OnQuestTaken?.Invoke(quest);
// //         }
// //
// //         public void ReceiveReward() {
// //             if (!this.CanReceiveReward()) {
// //                 throw new Exception("Can't receive quest reward!");
// //             }
// //
// //             var moneyReward = this.Quest.MoneyReward;
// //             this.moneyStorage.EarnMoney(moneyReward);
// //             this.moneyPanel.IncrementMoney(moneyReward);
// //
// //             var quest = this.Quest;
// //             quest.OnCompleted -= this.OnCompleteQuest;
// //             this.Quest = null;
// //
// //             this.factory.DestroyQuest(quest);
// //             this.OnQuestRewardReceived?.Invoke(quest);
// //         }
// //
// //         private void OnCompleteQuest(Quest quest) {
// //             this.OnQuestCompleted?.Invoke(quest);
// //         }
// //     }
// //
// //

using System.Threading.Tasks;

// public sealed class Repository
//       {
//           private Storage localStorage = new();
//           private Client client = new();
//
//           public async void SaveData(GameData data)
//           {
//               this.localStorage.Save(data); //Сохранение локально в файл
//               this.client.UploadData(data); //Сохранение на сервер
//           }
//       }
//
//
// //
// //     
// //     
//
//
//      // public sealed class MissionsSQLAdapter
//      // {
//      //     private SqliteDatabase database;
//      //     
//      //     public bool GetAllMissions(out List<MissionData> missions) {
//      //         missions = new List<MissionData>();
//      //         return this.database.SelectQuery("SELECT * FROM missions", missions, reader => new MissionData {
//      //             id = reader.GetString(0),
//      //             serializedState = reader.GetString(1)
//      //         });
//      //     }
//      //
//      //     public void RemoveAllMissions() {
//      //         this.database.DeleteQuery("DELETE FROM missions");
//      //     }
//      //
//      //     public void CreateMissions(MissionData[] missions) {
//      //         var serializedMissions = SqliteSerializer.Serialize(missions, data => new SqliteSerializer.Params(
//      //             data.id,
//      //             data.serializedState
//      //         ));
//      //         var command = string.Format("INSERT INTO missions (id, state) VALUES {0}", serializedMissions);
//      //         this.database.InsertQuery(command);
//      //     }
//      // }
//      //
//      //
//
//
//
// //     
// //     
// // }
// //
// //
// // public sealed class BackendServer {
// //     
// //     private readonly string url;
// //     private readonly int port;
// //
// //     public BackendServer(string url, int port) {
// //         this.url = url;
// //         this.port = port;
// //     }
// //
// //     public UnityWebRequest Get(string route) {
// //         var url = this.CombineUrl(route);
// //         return UnityWebRequest.Get(url);
// //     }
// //
// //     public UnityWebRequest Post(string route, string bodyJson) {
// //         var url = this.CombineUrl(route);
// //         var request = UnityWebRequest.Post(url, "POST");
// //         request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(bodyJson));
// //         request.downloadHandler = new DownloadHandlerBuffer();
// //         request.SetRequestHeader("Content-Type", "application/json");
// //         return request;
// //     }
// //
// //     public UnityWebRequest Put(string route, string bodyJson) {
// //         var url = this.CombineUrl(route);
// //         var request = UnityWebRequest.Put(url, bodyJson);
// //         request.SetRequestHeader("Content-Type", "application/json");
// //         return request;
// //     }
// //
// //     private string CombineUrl(string route) {
// //         return $"{this.url}:{this.port}/{route}";
// //     }
// // }
//
// public sealed class UpgradesManager
// {
//     public event Action<Upgrade> OnLevelUp;
//     private Dictionary<string, Upgrade> upgrades = new ();
//     private MoneyStorage moneyStorage;
//
//     public Upgrade GetUpgrade(string id) {
//         return this.upgrades[id];
//     }
//     
//     public bool CanLevelUp(Upgrade upgrade) {
//         if (upgrade.IsMaxLevel) {
//             return false;
//         }
//
//         var price = upgrade.NextPrice;
//         return this.moneyStorage.CanSpendMoney(price);
//     }
//
//     public void LevelUp(Upgrade upgrade) {
//         if (!this.CanLevelUp(upgrade)) {
//             throw new Exception($"Can not level up {upgrade.Id}");
//         }
//
//         var price = upgrade.NextPrice;
//         this.moneyStorage.SpendMoney(price);
//
//         upgrade.LevelUp();
//         this.OnLevelUp?.Invoke(upgrade);
//     }
// }
//
//
// public sealed class EnemySystem
// {
//     
// }
//
