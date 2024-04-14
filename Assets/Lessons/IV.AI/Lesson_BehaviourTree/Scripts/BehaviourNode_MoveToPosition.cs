using System;
using System.Collections;
using Entities;
using Game.GameEngine.Mechanics;
using Lessons.AI.HierarchicalStateMachine;
using Lessons.AI.LessonBehaviourTree;
using UnityEngine;

namespace Lessons.AI.Lesson_BehaviourTree
{
    public sealed class BehaviourNode_MoveToPosition : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;

        private Coroutine coroutine;
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(BlackboardKeys.UNIT, out IEntity unit) ||
                !this.blackboard.TryGetVariable(BlackboardKeys.STOPPING_DISTANCE, out float stoppingDistance))
            {
                this.Return(false);
                return;
            }

            this.coroutine = this.StartCoroutine(this.MoveToPosition(unit, stoppingDistance));
        }
        
        protected override void OnAbort()
        {
            if (this.coroutine != null)
            {
                this.StopCoroutine(this.coroutine);
            }
        }

        private IEnumerator MoveToPosition(IEntity unit, float stoppingDistance)
        {
            IComponent_GetPosition positionComponent = unit.Get<IComponent_GetPosition>();
            IComponent_MoveInDirection moveComponent = unit.Get<IComponent_MoveInDirection>();
            
            var period = new WaitForFixedUpdate();

            while (true)
            {
                if (!this.blackboard.TryGetVariable(BlackboardKeys.MOVE_POSITION, out Vector3 targetPosition))
                {
                    this.Return(false);
                    yield break; 
                }

                Vector3 currentPosition = positionComponent.Position;
                Vector3 distanceVector = targetPosition - currentPosition;

                if (distanceVector.magnitude <= stoppingDistance)
                {
                    break;
                }

                Vector3 direction = distanceVector.normalized;
                moveComponent.Move(direction);

                yield return period;
            }
            
            yield return period;

            this.Return(true);
        }
    }
}