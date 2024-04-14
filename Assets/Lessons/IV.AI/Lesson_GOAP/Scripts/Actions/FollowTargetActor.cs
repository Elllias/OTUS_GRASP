using AI.Blackboards;
using AI.GOAP;
using Elementary;
using Entities;
using Game.GameEngine.AI;
using Game.GameEngine.Entities;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class FollowTargetActor : Actor, IBlackboardInjective
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

        private readonly Agent_Entity_FollowEntity followAgent = new();

        private void Awake()
        {
            this.followAgent.SetStoppingDistance(this.stoppingDistance.Current);
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
            
            this.followAgent.OnTargetReached += this.OnTargetReached;
            this.followAgent.SetFollowingEntity(unit);
            this.followAgent.SetTargetEntity(target);
            this.followAgent.Play();
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
            this.followAgent.OnTargetReached -= this.OnTargetReached;
            this.followAgent.Stop();
        }
    }
}