using AI.Blackboards;
using AI.GOAP;
using AI.Waypoints;
using Elementary;
using Entities;
using Game.GameEngine.AI;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class PatrolByPointsActor : Actor, IBlackboardInjective
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
        private string waypointsKey;

        private readonly Agent_Entity_MoveByPoints moveAgent = new();

        private void Awake()
        {
            this.moveAgent.SetStoppingDistance(this.stoppingDistance.Current);
        }

        public override int EvaluateCost()
        {
            return 0;
        }

        public override bool IsValid()
        {
            return this.Blackboard.HasVariable(this.unitKey) &&
                   this.Blackboard.HasVariable(this.waypointsKey);
        }

        protected override void Play()
        {
            if (!this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }

            if (!this.Blackboard.TryGetVariable(this.waypointsKey, out WaypointsPath waypoints))
            {
                this.Return(false);
                return;
            }

            this.moveAgent.OnPathFinished += this.OnPathFinished;
            this.moveAgent.SetMovingEntity(unit);
            this.moveAgent.SetPath(waypoints.GetPositionPoints());
            this.moveAgent.Play();
        }

        protected override void OnDispose()
        {
            this.moveAgent.OnPathFinished -= this.OnPathFinished;
            this.moveAgent.Stop();
        }

        private void OnPathFinished()
        {
            this.Return(true);
        }
    }
}