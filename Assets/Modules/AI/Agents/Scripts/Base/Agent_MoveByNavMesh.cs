using System;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Agents
{
    public abstract class Agent_MoveByNavMesh : Agent
    {
        public event Action OnPositionReached
        {
            add { this.MoveAgent.OnPathFinished += value; }
            remove { this.MoveAgent.OnPathFinished -= value; }
        }

        public bool IsPathFinished
        {
            get { return this.MoveAgent.IsPathFinished; }
        }

        protected abstract Agent_MoveByPoints<Vector3> MoveAgent { get; }

        private readonly NavMeshPath currentPath = new();

        private int navMeshAreas;

        public void SetNavMeshAreas(int navMeshAreas)
        {
            this.navMeshAreas = navMeshAreas;
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            var currentPosition = this.EvaluateCurrentPosition();
            if (NavMesh.CalculatePath(
                    currentPosition,
                    targetPosition,
                    this.navMeshAreas,
                    this.currentPath
                ))
            {
                this.MoveAgent.SetPath(this.currentPath.corners);
            }
            else
            {
                Debug.LogWarning($"Can not calculate path to {targetPosition}");
            }
        }

        protected override void OnStart()
        {
            this.MoveAgent.Play();
        }

        protected override void OnStop()
        {
            this.MoveAgent.Stop();
        }

        protected abstract Vector3 EvaluateCurrentPosition();
    }
}