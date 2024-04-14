using System.Collections.Generic;
using AI.Blackboards;
using AI.BTree;
using UnityEngine;

namespace Game.GameEngine.AI
{
    public abstract class UBTNode_FindMovePath : UnityBehaviourNode, IBlackboardInjective
    {
        private const int POINT_BUFFER_SIZE = 64;
        
        public IBlackboard Blackboard { protected get; set; }

        [BlackboardKey]
        [SerializeField]
        private string endPositionKey;

        [BlackboardKey]
        [SerializeField]
        private string movePathKey;

        private List<Vector3> pointsBuffer;
        
        public UBTNode_FindMovePath()
        {
            this.pointsBuffer = new List<Vector3>(POINT_BUFFER_SIZE);
        }

        protected override void Run()
        {
            if (!this.Blackboard.TryGetVariable(this.endPositionKey, out Vector3 endPosition))
            {
                Debug.LogWarning("End Point is not found!");
                this.Return(false);
                return;
            }

            if (!this.FindPath(this.ProvideStartPosition(), endPosition, ref this.pointsBuffer))
            {
                Debug.LogWarning("Path is not found!");
                this.Return(false);
                return;
            }
            
            var movePoints = this.pointsBuffer.ToArray();
            this.Blackboard.ReplaceVariable(this.movePathKey, movePoints);
            this.Return(true);
        }

        protected abstract Vector3 ProvideStartPosition();

        protected abstract bool FindPath(Vector3 startPosition, Vector3 endPosition, ref List<Vector3> path);
    }
}