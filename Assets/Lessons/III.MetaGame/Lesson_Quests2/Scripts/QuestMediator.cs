// using Game.App;
// using Services;
//
// namespace Lessons.Meta
// {
//     public sealed class QuestMediator : IGameSaveDataListener, IGameDataConverter
//     {
//         private QuestRepository repository;
//
//         private QuestAssetSupplier assetSupplier;
//
//         private QuestManager questManager;
//
//         [ServiceInject]
//         public void Construct(QuestRepository repository, QuestAssetSupplier assetSupplier)
//         {
//             this.repository = repository;
//             this.assetSupplier = assetSupplier;
//         }
//
//         void IGameDataConverter.LoadData(GameFacade gameFacade)
//         {
//             this.questManager = gameFacade.GetService<QuestManager>();
//
//             if (this.repository.LoadQuest(out var data))
//             {
//                 QuestConfig config = this.assetSupplier.GetQuest(data.id);
//                 this.questManager.SetupQuest(config);
//                 config.Deserialize(data.serializedState, this.questManager.Quest);
//             }
//         }
//
//         void IGameSaveDataListener.OnSaveData(GameSaveReason reason)
//         {
//             if (this.questManager.QuestExists)
//             {
//                 this.SaveQuest();
//             }
//             else
//             {
//                 this.repository.RemoveQuest();
//             }
//         }
//
//         private void SaveQuest()
//         {
//             Quest quest = this.questManager.Quest;
//             QuestConfig questConfig = this.assetSupplier.GetQuest(quest.Id);
//
//             QuestData data = new QuestData
//             {
//                 id = quest.Id,
//                 serializedState = questConfig.Serialize(quest)
//             };
//
//             this.repository.SaveQuest(data);
//         }
//     }
// }