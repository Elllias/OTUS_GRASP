using System;
using AI.Blackboards;
using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using Declarative;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [Serializable]
    public sealed class State_Entity_FollowToEntity : State, IFixedUpdateListener
    {
        public string UnitKey
        {
            set => unitKey = value;
        }

        public string TargetKey
        {
            set => targetKey = value;
        }

        public string StoppingDistanceKey
        {
            set => stoppingDistanceKey = value;
        }

        private Agent_Entity_MoveToPosition moveAgent = new();

        private IBlackboard blackboard;

        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        [BlackboardKey]
        [SerializeField]
        private string stoppingDistanceKey;

        private IComponent_GetPosition targetPositionComponent;

        private bool enabled;

        public void Construct(IBlackboard blackboard, float stoppingDistance)
        {
            this.blackboard = blackboard;
            this.moveAgent.SetStoppingDistance(stoppingDistance);
        }

        public override void Enter()
        {
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                return;
            }

            if (!this.blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                return;
            }

            if (!this.blackboard.TryGetVariable(this.stoppingDistanceKey, out float stoppingDistance))
            {
                return;
            }

            this.targetPositionComponent = target.Get<IComponent_GetPosition>();

            this.moveAgent.SetMovingEntity(unit); //Unit
            this.moveAgent.SetStoppingDistance(stoppingDistance); //Stopping Distance
            this.moveAgent.SetTarget(this.targetPositionComponent.Position);
            this.moveAgent.Play();
            
            this.enabled = true;
        }

        public override void Exit()
        {
            this.enabled = false;
            this.moveAgent.Stop();
        }

        void IFixedUpdateListener.FixedUpdate(float deltaTime)
        {
            if (this.enabled)
            {
                var nextPosition = this.targetPositionComponent.Position;
                this.moveAgent.SetTarget(nextPosition);
            }
        }
    }
}