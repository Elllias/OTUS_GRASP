using Elementary;
using Sirenix.OdinInspector;

namespace Game.GameEngine.Mechanics
{
    public sealed class HarvestResourceState_TimeProgress : StateFixedUpdate
    {
        private IOperator<HarvestResourceOperation> harvestOperator;

        private IValue<float> duration;

        [ReadOnly, ShowInInspector]
        private float currentTime;

        public void ConstructOperator(IOperator<HarvestResourceOperation> harvestOperator)
        {
            this.harvestOperator = harvestOperator;
        }

        public void ConstructDuration(IValue<float> duration)
        {
            this.duration = duration;
        }

        protected override void OnEnter()
        {
            this.currentTime = this.harvestOperator.Current.progress * this.duration.Current;
        }

        protected override void FixedUpdate(float deltaTime)
        {
            if (this.harvestOperator.IsActive)
            {
                if (this.currentTime < this.duration.Current)
                {
                    this.UpdateProgress(deltaTime);
                }
                else
                {
                    this.Complete();
                }    
            }
        }

        private void UpdateProgress(float deltaTime)
        {
            this.currentTime += deltaTime;
            var progress = this.currentTime / this.duration.Current;
            this.harvestOperator.Current.progress = progress;
        }

        private void Complete()
        {
            var operation = this.harvestOperator.Current;
            operation.isCompleted = true;
            operation.progress = 1.0f;
            this.harvestOperator.Stop();
        }
    }
}