using AI.Blackboards;
using AI.BTree;
using Elementary;
using Entities;
using UnityEngine;
using UnityEngine.AI;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "BTNode «Follow Entity By NavMesh» (Entity)")]
    public sealed class UBTNode_Entity_FollowEntityByNavMesh : UnityBehaviourNode, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [Space]
        [SerializeField]
        private FloatAdapter stoppingDistance; // 0.15f;

        [SerializeField]
        private FloatAdapter minPointDistance; //0.15f;

        [Space]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        private Agent_Entity_FollowEntityByNavMesh followAgent;

        private void Awake()
        {
            this.followAgent = new Agent_Entity_FollowEntityByNavMesh();
            this.followAgent.SetNavMeshAreas(NavMesh.AllAreas);
            this.followAgent.SetStoppingDistance(this.stoppingDistance.Current);
            this.followAgent.SetMinPointDistance(this.minPointDistance.Current);
            this.followAgent.SetCalculatePathPeriod(new WaitForFixedUpdate());
            this.followAgent.SetCheckTargetReachedPeriod(null);
        }

        protected override void Run()
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
            this.followAgent.SetTargetEntity(target);
            this.followAgent.SetFollowingEntity(unit);
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
            this.followAgent.Stop();
            this.followAgent.OnTargetReached -= this.OnTargetReached;
        }
    }
}