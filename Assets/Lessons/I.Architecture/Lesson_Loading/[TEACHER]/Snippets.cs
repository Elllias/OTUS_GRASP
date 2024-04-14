// namespace Lessons.I.Architecture.Lesson_Loading._TEACHER_
// {
     // public class Snippets
     // {
     //     [SerializeField]
     //     private LoadingTask[] loadingTasks;
     //     
     //     public async void Start()
     //     {
     //         foreach (var task in this.loadingTasks)
     //         {
     //             var result = await task.Do();
     //             if (!result.success)
     //             {
     //                 LoadingScreen.ReportError(result.error);
     //                 break;
     //             }
     //         }
     //     }



// public sealed class ApplicationLoader : MonoBehaviour
//     {
//         public void Start()
//         {
//             //Запуск плагинов:
//             AppsFlyer.startSDK();
//             FB.Init(this.OnFacebookInitialized, LoadingScreen.ReportError);
//         }
//
//         private async void OnFacebookInitialized()
//         {
//             //Инициализация встроенных покупок:
//             await UnityServices.InitializeAsync();
//             var purchasing = new PurchaseManager();
//             purchasing.Initialize(result =>
//             {
//                 if (result.isSuccess)
//                 {
//                     this.OnPurchasingInitialized();
//                 }
//                 else
//                 {
//                     LoadingScreen.ReportError("Встроенные покупки не загружены!");
//                 }
//             });
//         }
//
//         private void OnPurchasingInitialized()
//         {
//             //Подключение к Social Platform:
//             Social.localUser.Authenticate(b =>
//             {
//                 if (b)
//                 {
//                     this.OnAuthorizationSucceed();
//                 }
//                 else
//                 {
//                     LoadingScreen.ReportError("Ошибка авторизации!");
//                 }
//             });
//         }
//
//         private async void OnAuthorizationSucceed()
//         {
//             //Загрузка сцены:
//             await this.LoadGameScene();
//
//             //Загрузка попапов из Addressables:
//             var popupCatalog = Resources.Load<PopupCatalog>(nameof(PopupCatalog));
//             await popupCatalog.LoadAssets();
//             LoadingScreen.ReportProgress(0.8f);
//
//             //Инициализация игровой системы:
//             var ctx = GameObject.FindWithTag(nameof(GameContext)).GetComponent<GameContext>();
//             ctx.ConstructGame();
//
//             //Загрузка данных:
//             var dataLoader = new GameDataLoader();
//             await dataLoader.LoadData(ctx);
//             LoadingScreen.ReportProgress(0.9f);
//
//             //Запуск игры:
//             ctx.InitGame();
//             ctx.ReadyGame();
//             ctx.StartGame();
//
//             LoadingScreen.ReportProgress(1f);
//             await new WaitForSeconds(0.5f);
//             LoadingScreen.Hide();
//         }
//
//         private IEnumerator LoadGameScene()
//         {
//             var operation = SceneManager.LoadSceneAsync("Game/Scenes/GameScene");
//             while (!operation.isDone)
//             {
//                 LoadingScreen.ReportProgress(operation.progress / 2);
//                 yield return null;
//             }
//
//             LoadingScreen.ReportProgress(0.5f);
//         }
//     }

//     }
// }