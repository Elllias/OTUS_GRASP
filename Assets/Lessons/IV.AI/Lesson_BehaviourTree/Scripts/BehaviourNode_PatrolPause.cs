using System.Collections;
using Lessons.AI.HierarchicalStateMachine;
using Lessons.AI.LessonBehaviourTree;
using UnityEngine;
using Blackboard = Lessons.AI.HierarchicalStateMachine.Blackboard;

namespace Lessons.AI.Lesson_BehaviourTree
{
    public sealed class BehaviourNode_PatrolPause : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;
        
        private Coroutine coroutine;
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(BlackboardKeys.PATROL_IDLE_TIME, out float pauseTime))
            {
                this.Return(false);
                return;
            }

            this.coroutine = this.StartCoroutine(this.Pause(pauseTime));
        }

        protected override void OnAbort()
        {
            if (this.coroutine != null)
            {
                this.StopCoroutine(this.coroutine);
            }
        }

        private IEnumerator Pause(float pauseTime)
        {
            yield return new WaitForSeconds(pauseTime);
            this.Return(true);
        }
    }
}