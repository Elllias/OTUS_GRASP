using Newtonsoft.Json;
using Services;

namespace Game.App
{
    public abstract class GameMediator<TData, TGameService> : IGameMediator
    {
        protected virtual string DataKey
        {
            get { return typeof(TData).Name; }
        }

        [ServiceInject]
        private GameFacade gameFacade;

        void IGameMediator.SetupData(GameRepository repository)
        {
            var service = this.gameFacade.GetService<TGameService>();

            if (repository.TryGetData(this.DataKey, out var json))
            {
                var data = JsonConvert.DeserializeObject<TData>(json);
                this.SetupFromData(service, data);
            }
            else
            {
                this.SetupByDefault(service);
            }
        }

        void IGameMediator.SaveData(GameRepository repository)
        {
            var service = this.gameFacade.GetService<TGameService>();
            var data = this.ConvertToData(service);
            var json = JsonConvert.SerializeObject(data);
            repository.SetData(this.DataKey, json);
        }

        protected abstract void SetupFromData(TGameService service, TData data);

        protected abstract void SetupByDefault(TGameService service);

        protected abstract TData ConvertToData(TGameService service);
    }
}