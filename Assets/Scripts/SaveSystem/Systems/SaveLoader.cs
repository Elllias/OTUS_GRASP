using System.IO;
using Lessons.Architecture.DI;
using Newtonsoft.Json;
using SaveSystem.Interfaces;
using SaveSystem.Utils;

namespace SaveSystem.Systems
{
    public abstract class SaveLoader<TService, TData> : ISaveLoader where TService : class
    {
        public void Save(IGameRepository repository)
        {
            var service = ServiceLocator.GetService<TService>();
            var data = ConvertToData(service);
            
            repository.SetData(data);
        }

        public void Load(IGameRepository repository)
        {
            var service = ServiceLocator.GetService<TService>();

            if (repository.TryGetData(out TData data))
            {
                SetupData(service, data);
            }
        }

        protected abstract TData ConvertToData(TService service);
        protected abstract void SetupData(TService service, TData resourceContainerData);
    }
}