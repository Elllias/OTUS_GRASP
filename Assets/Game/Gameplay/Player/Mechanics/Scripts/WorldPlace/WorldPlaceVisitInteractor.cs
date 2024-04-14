using System;
using Game.GameEngine;
using Sirenix.OdinInspector;

namespace Game.Gameplay.Player
{
    public sealed class WorldPlaceVisitInteractor
    {
        public event Action<WorldPlaceType> OnVisitStarted;
        
        public event Action<WorldPlaceType> OnVisitEnded;
        
        [ShowInInspector, ReadOnly]
        public bool IsVisiting { get; private set; }

        [ShowInInspector, ReadOnly]
        public WorldPlaceType CurrentPlace { get; private set; }
        
        public void StartVisit(WorldPlaceType type)
        {
            if (this.IsVisiting)
            {
                throw new Exception("Other visit place is already started!");
            }

            this.IsVisiting = true;
            this.CurrentPlace = type;
            this.OnVisitStarted?.Invoke(type);
        }

        public void EndVisit()
        {
            if (!this.IsVisiting)
            {
                return;
            }

            this.IsVisiting = false;
            this.OnVisitEnded?.Invoke(this.CurrentPlace);
        }
    }
}