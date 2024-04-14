using System.Collections.Generic;
using GameSystem;

namespace Game.App
{
    public sealed class GameFacade
    {
        private readonly List<object> registeredServices;
        
        private readonly List<IGameElement> registeredElements;
        
        private GameContext context;

        public GameFacade()
        {
            this.registeredServices = new List<object>();
            this.registeredElements = new List<IGameElement>();
        }
        
        public void SetupGame(GameContext context)
        {
            for (int i = 0, count = this.registeredServices.Count; i < count; i++)
            {
                var service = this.registeredServices[i];
                context.RegisterService(service);
            }
        
            for (int i = 0, count = this.registeredElements.Count; i < count; i++)
            {
                var element = this.registeredElements[i];
                context.RegisterElement(element);
            }

            this.context = context;
        }

        public void ConstructGame()
        {
            this.context.ConstructGame();
        }

        public void InitGame()
        {
            this.context.InitGame();
        }

        public void ReadyGame()
        {
            this.context.ReadyGame();
        }

        public void StartGame()
        {
            this.context.StartGame();
        }

        public T GetService<T>()
        {
            return this.context.GetService<T>();
        }

        public T[] GetServices<T>()
        {
            return this.context.GetServices<T>();
        }

        public bool TryGetService<T>(out T result)
        {
            return this.context.TryGetService(out result);
        }

        public void RegisterService(object service)
        {
            this.registeredServices.Add(service);
            if (this.context != null)
            {
                this.context.RegisterService(service);
            }
        }

        public void UnregisterService(object service)
        {
            this.registeredServices.Remove(service);
            if (this.context != null)
            {
                this.context.UnregisterService(service);
            }
        }

        public void RegisterElement(IGameElement element)
        {
            this.registeredElements.Add(element);
            if (this.context != null)
            {
                this.context.RegisterElement(element);
            }
        }

        public void UnregisterElement(IGameElement element)
        {
            this.registeredElements.Remove(element);
            if (this.context != null)
            {
                this.context.UnregisterElement(element);
            }
        }
    }
}