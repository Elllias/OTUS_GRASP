using System.Collections;
using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Harvest Resource/Harvest Resource State «Time Progress»")]
    public sealed class UHarvestResourceState_TimeProgress : MonoStateCoroutine
    {
        [SerializeField]
        private UHarvestResourceOperator engine;
        
        [Space]
        [SerializeField]
        private FloatAdapter workTime;
        
        [ReadOnly]
        [ShowInInspector]
        private float currentTime;

        public override void Enter()
        {
            this.currentTime = this.engine.Current.progress * this.workTime.Current;
            base.Enter();
        }

        protected override IEnumerator Do()
        {
            while (this.currentTime < this.workTime.Current)
            {
                yield return null;
                this.UpdateProgress(Time.deltaTime);
            }

            this.Complete();
        }

        private void UpdateProgress(float deltaTime)
        {
            this.currentTime += deltaTime;
            var progress = this.currentTime / this.workTime.Current;
            this.engine.Current.progress = progress;
        }

        private void Complete()
        {
            var operation = this.engine.Current;
            operation.isCompleted = true;
            operation.progress = 1.0f;
            this.engine.Stop();
        }
    }
}