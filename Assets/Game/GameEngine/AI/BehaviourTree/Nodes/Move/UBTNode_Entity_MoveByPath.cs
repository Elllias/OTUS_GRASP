using AI.Blackboards;
using AI.BTree;
using Elementary;
using Entities;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "BTNode «Move By Path» (Entity)")]
    public sealed class UBTNode_Entity_MoveByPath : UnityBehaviourNode, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string movePathKey;
        
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [Space]
        [SerializeField]
        private FloatAdapter stoppingDistance;

        private Agent_Entity_MoveByPoints moveAgent;

        private void Awake()
        {
            this.moveAgent = new Agent_Entity_MoveByPoints();
            this.moveAgent.SetStoppingDistance(this.stoppingDistance.Current);
        }

        protected override void Run()
        {
            if (!this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                Debug.LogWarning("Unit is not found!");
                this.Return(false);
                return;
            }

            if (!this.Blackboard.TryGetVariable(this.movePathKey, out Vector3[] movePositions))
            {
                Debug.LogWarning("Move path is not found!");
                this.Return(false);
                return;
            }

            this.moveAgent.OnPathFinished += this.OnMoveFinished;
            this.moveAgent.SetMovingEntity(unit);
            this.moveAgent.SetPath(movePositions);
            this.moveAgent.Play();
        }

        private void OnMoveFinished()
        {
            this.Return(true);
        }

        protected override void OnDispose()
        {
            this.moveAgent.OnPathFinished -= this.OnMoveFinished;
            this.moveAgent.Stop();
        }
    }
}