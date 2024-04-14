// using Services;
//
// namespace Game.App
// {
//     public abstract class BaseMediator<TRepository, TGameService> :
//         IGameDataConverter,
//         IGameSaveDataListener
//     {
//         private TRepository repository;
//
//         private TGameService gameService;
//
//         void IGameDataConverter.LoadData(GameFacade gameFacade)
//         {
//             this.repository = ServiceLocator.GetService<TRepository>();
//             this.gameService = gameFacade.GetService<TGameService>();
//             this.OnLoadData(this.repository, this.gameService);
//         }
//
//         void IGameSaveDataListener.OnSaveData(GameSaveReason reason)
//         {
//             this.OnSaveData(this.repository, this.gameService);
//         }
//
//         protected abstract void OnLoadData(TRepository repository, TGameService gameService);
//
//         protected abstract void OnSaveData(TRepository repository, TGameService gameService);
//     }
// }