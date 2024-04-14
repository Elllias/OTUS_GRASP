using System.Collections.Generic;
using System.Linq;

namespace GameSystem
{
    internal sealed class ElementContext
    {
        private readonly GameContext context;

        private readonly HashSet<IGameElement> gameElements;

        private readonly List<IGameElement> cache;

        private readonly List<IGameUpdateElement> updateListeners = new();

        private readonly List<IGameFixedUpdateElement> fixedUpdateListeners = new();

        private readonly List<IGameLateUpdateElement> lateUpdateListeners = new();

        internal ElementContext(GameContext context)
        {
            this.context = context;
            this.gameElements = new HashSet<IGameElement>();
            this.cache = new List<IGameElement>();
        }

        internal void AddElement(IGameElement element)
        {
            if (element == null)
            {
                return;
            }

            var addedElements = new HashSet<IGameElement>();
            this.AddRecursively(element, ref addedElements);

            foreach (var addedElement in addedElements)
            {
                this.TryActivateElement(addedElement);
                this.TryAddListener(addedElement);
            }
        }

        internal void RemoveElement(IGameElement element)
        {
            if (element != null)
            {
                this.RemoveRecursively(element);
            }
        }

        internal object[] GetAllElements()
        {
            return this.gameElements.ToArray<object>();
        }

        internal void ConstructGame()
        {
            this.cache.Clear();
            this.cache.AddRange(this.gameElements);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var element = this.cache[i];
                if (element is IGameConstructElement constructElement)
                {
                    constructElement.ConstructGame(this.context);
                }
            }
        }

        internal void InitGame()
        {
            this.cache.Clear();
            this.cache.AddRange(this.gameElements);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var element = this.cache[i];
                if (element is IGameInitElement initElement)
                {
                    initElement.InitGame();
                }
            }
        }

        internal void ReadyGame()
        {
            this.cache.Clear();
            this.cache.AddRange(this.gameElements);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var element = this.cache[i];
                if (element is IGameReadyElement initElement)
                {
                    initElement.ReadyGame();
                }
            }
        }

        internal void StartGame()
        {
            this.cache.Clear();
            this.cache.AddRange(this.gameElements);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var element = this.cache[i];
                if (element is IGameStartElement startElement)
                {
                    startElement.StartGame();
                }
            }
        }

        internal void FixedUpdate(float deltaTime)
        {
            for (int i = 0, count = this.fixedUpdateListeners.Count; i < count; i++)
            {
                var listener = this.fixedUpdateListeners[i];
                listener.OnFixedUpdate(deltaTime);
            }
        }

        internal void Update(float deltaTime)
        {
            for (int i = 0, count = this.updateListeners.Count; i < count; i++)
            {
                var listener = this.updateListeners[i];
                listener.OnUpdate(deltaTime);
            }
        }

        internal void LateUpdate(float deltaTime)
        {
            for (int i = 0, count = this.lateUpdateListeners.Count; i < count; i++)
            {
                var listener = this.lateUpdateListeners[i];
                listener.OnLateUpdate(deltaTime);
            }
        }

        internal void PauseGame()
        {
            this.cache.Clear();
            this.cache.AddRange(this.gameElements);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var element = this.cache[i];
                if (element is IGamePauseElement startElement)
                {
                    startElement.PauseGame();
                }
            }
        }

        internal void ResumeGame()
        {
            this.cache.Clear();
            this.cache.AddRange(this.gameElements);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var element = this.cache[i];
                if (element is IGameResumeElement startElement)
                {
                    startElement.ResumeGame();
                }
            }
        }

        internal void FinishGame()
        {
            this.cache.Clear();
            this.cache.AddRange(this.gameElements);

            for (int i = 0, count = this.cache.Count; i < count; i++)
            {
                var element = this.cache[i];
                if (element is IGameFinishElement finishElement)
                {
                    finishElement.FinishGame();
                }
            }
        }

        private void AddRecursively(IGameElement element, ref HashSet<IGameElement> addedElements)
        {
            if (this.gameElements.Add(element))
            {
                addedElements.Add(element);
            }

            if (element is IGameElementGroup elementGroup)
            {
                foreach (var child in elementGroup.GetElements())
                {
                    this.AddRecursively(child, ref addedElements);
                }
            }
        }

        private void RemoveRecursively(IGameElement element)
        {
            this.RemoveElementInternal(element);

            if (element is IGameElementGroup elementGroup)
            {
                foreach (var child in elementGroup.GetElements())
                {
                    this.RemoveRecursively(child);
                }
            }
        }

        private void RemoveElementInternal(IGameElement element)
        {
            this.gameElements.Remove(element);
            if (element is IGameDetachElement detachElement)
            {
                detachElement.DetachGame(this.context);
            }

            this.TryRemoveListener(element);
        }

        private void TryActivateElement(IGameElement element)
        {
            if (element is IGameAttachElement attachElement)
            {
                attachElement.AttachGame(this.context);
            }

            var gameState = this.context.CurrentState;
            if (gameState >= GameContext.State.FINISH)
            {
                return;
            }

            if (gameState < GameContext.State.CONSTRUCT)
            {
                return;
            }

            if (element is IGameConstructElement constructElement)
            {
                constructElement.ConstructGame(this.context);
            }

            if (gameState < GameContext.State.INIT)
            {
                return;
            }

            if (element is IGameInitElement initElement)
            {
                initElement.InitGame();
            }

            if (gameState < GameContext.State.READY)
            {
                return;
            }

            if (element is IGameReadyElement readyElement)
            {
                readyElement.ReadyGame();
            }

            if (gameState < GameContext.State.PLAY)
            {
                return;
            }

            if (element is IGameStartElement startElement)
            {
                startElement.StartGame();
            }

            if (gameState == GameContext.State.PAUSE && element is IGamePauseElement pauseElement)
            {
                pauseElement.PauseGame();
            }
        }

        private void TryAddListener(IGameElement listener)
        {
            if (listener is IGameUpdateElement updateElement)
            {
                this.updateListeners.Add(updateElement);
            }

            if (listener is IGameFixedUpdateElement fixedUpdateElement)
            {
                this.fixedUpdateListeners.Add(fixedUpdateElement);
            }

            if (listener is IGameLateUpdateElement lateUpdateElement)
            {
                this.lateUpdateListeners.Add(lateUpdateElement);
            }
        }

        private void TryRemoveListener(IGameElement listener)
        {
            if (listener is IGameUpdateElement updateElement)
            {
                this.updateListeners.Remove(updateElement);
            }

            if (listener is IGameFixedUpdateElement fixedUpdateElement)
            {
                this.fixedUpdateListeners.Remove(fixedUpdateElement);
            }

            if (listener is IGameLateUpdateElement lateUpdateElement)
            {
                this.lateUpdateListeners.Remove(lateUpdateElement);
            }
        }
    }
}