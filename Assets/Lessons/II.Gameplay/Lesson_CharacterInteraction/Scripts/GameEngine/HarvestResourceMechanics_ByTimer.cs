using Elementary;
using Lessons.Gameplay.CharacterInteraction;
using UnityEngine;

namespace Lessons.Gameplay.Lesson_CharacterInteraction
{
    public sealed class HarvestResourceMechanics_ByTimer : MonoBehaviour
    {
        [SerializeField]
        private HarvestResourceEngine engine;

        [SerializeField]
        private MonoTimer countdown;
        
        // private float speed;

        private void OnEnable()
        {
            this.engine.OnStarted += this.OnHarvestStarted;
            this.engine.OnStopped += this.OnHarvestFinished;
            this.countdown.OnFinished += this.OnTimerFinished;
        }

        private void OnDisable()
        {
            this.engine.OnStarted -= this.OnHarvestStarted;
            this.engine.OnStopped -= this.OnHarvestFinished;
            this.countdown.OnFinished -= this.OnTimerFinished;
        }

        private void OnHarvestStarted(HarvestResourceOperation operation)
        {
            this.countdown.ResetTime();
            this.countdown.Play();
        }

        private void OnHarvestFinished(HarvestResourceOperation operation)
        {
            this.countdown.Stop();
        }

        private void OnTimerFinished()
        {
            this.engine.CurrentOperation.isCompleted = true;
            this.engine.StopHarvest();
        }
    }
}