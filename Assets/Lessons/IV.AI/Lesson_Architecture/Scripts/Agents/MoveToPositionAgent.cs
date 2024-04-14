using System.Collections;
using Entities;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.AI.Architecture
{
    public sealed class MoveToPositionAgent : Agent
    {
        [ShowInInspector, ReadOnly]
        private IEntity unit;

        [ShowInInspector, ReadOnly]
        private float stoppingDistance;

        [ShowInInspector, ReadOnly]
        private Vector3 targetPosiiton;

        private IComponent_GetPosition positionComponent;
        private IComponent_MoveInDirection moveComponent;

        private Coroutine moveCoroutine;

        private bool isReached;

        public bool IsReached
        {
            get { return this.isReached; }
        }

        [Button]
        public void SetTargetPosiiton(Transform point)
        {
            this.targetPosiiton = point.position;
        }

        public void SetTargetPosiiton(Vector3 position)
        {
            this.targetPosiiton = position;
        }

        [Button]
        public void SetStoppingDistance(float stoppingDistance)
        {
            this.stoppingDistance = stoppingDistance;
        }

        [Button]
        public void SetUnit(IEntity unit)
        {
            this.unit = unit;
            this.positionComponent = unit?.Get<IComponent_GetPosition>();
            this.moveComponent = unit?.Get<IComponent_MoveInDirection>();
        }

        protected override void OnStart()
        {
            this.isReached = false;
            this.moveCoroutine = this.StartCoroutine(this.MoveRoutine());
        }

        protected override void OnStop()
        {
            if (this.moveCoroutine != null)
            {
                this.StopCoroutine(this.moveCoroutine);
                this.moveCoroutine = null;
            }
        }

        private IEnumerator MoveRoutine()
        {
            var period = new WaitForFixedUpdate();

            while (true)
            {
                if (this.unit != null)
                {
                    this.DoMove();
                }

                yield return period;
            }
        }

        private void DoMove()
        {
            var myPosition = this.positionComponent.Position;
            var distanceVector = this.targetPosiiton - myPosition;

            this.isReached = distanceVector.sqrMagnitude <= this.stoppingDistance * this.stoppingDistance;

            if (!this.isReached)
            {
                var moveDirection = distanceVector.normalized;
                this.moveComponent.Move(moveDirection);
            }
            else
            {
                Debug.Log("Position Reached");
            }
        }
    }
}