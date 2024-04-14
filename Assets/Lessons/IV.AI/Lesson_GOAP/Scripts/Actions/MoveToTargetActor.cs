using AI.Blackboards;
using AI.GOAP;
using Elementary;
using Entities;
using Game.GameEngine.AI;
using Game.GameEngine.Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class MoveToTargetActor : Actor, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [Space]
        [SerializeField]
        private FloatAdapter stoppingDistance;

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        private readonly Agent_Entity_MoveToPosition moveAgent = new();

        private void Awake()
        {
            this.moveAgent.SetStoppingDistance(this.stoppingDistance.Current);
        }

        public override int EvaluateCost()
        {
            var unit = this.Blackboard.GetVariable<IEntity>(this.unitKey);
            var target = this.Blackboard.GetVariable<IEntity>(this.targetKey);
            var distanceVector = EntityUtils.DistanceVector(unit, target);
            return Mathf.RoundToInt(distanceVector.magnitude);
        }

        public override bool IsValid()
        {
            return this.Blackboard.HasVariable(this.unitKey) &&
                   this.Blackboard.HasVariable(this.targetKey);
        }

        protected override void Play()
        {
            if (!this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }

            if (!this.Blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                this.Return(false);
                return;
            }
            
            var targetPosition = target.Get<IComponent_GetPosition>().Position;

            this.moveAgent.OnTargetReached += this.OnTargetReached;
            this.moveAgent.SetMovingEntity(unit);
            this.moveAgent.SetTarget(targetPosition);
            this.moveAgent.Play();
        }

        private void OnTargetReached(bool isReached)
        {
            if (isReached)
            {
                this.Return(true);
            }
        }

        protected override void OnDispose()
        {
            this.moveAgent.OnTargetReached -= this.OnTargetReached;
            this.moveAgent.Stop();
        }
    }
}