using System;
using Lessons.Gameplay.Lesson_CharacterInteraction;
using UnityEngine;

namespace Lessons.Gameplay.CharacterInteraction
{
    public sealed class Component_HarvestResource : MonoBehaviour, IComponent_HarvestResource
    {
        public event Action<HarvestResourceOperation> OnStarted
        {
            add { this.engine.OnStarted += value; }
            remove { this.engine.OnStarted -= value; }
        }

        public event Action<HarvestResourceOperation> OnFinished
        {
            add { this.engine.OnStopped += value; }
            remove { this.engine.OnStopped -= value; }
        }

        public bool IsHarvesting
        {
            get { return this.engine.IsHarvesting; }
        }

        [SerializeField]
        private HarvestResourceEngine engine;

        public bool CanStartHarvest(HarvestResourceOperation operation)
        {
            return this.engine.CanStartHarvest(operation);
        }

        public void StartHarvest(HarvestResourceOperation operation)
        {
            this.engine.StartHarvest(operation);
        }

        public void StopHarvest()
        {
            this.engine.StopHarvest();
        }
    }
}