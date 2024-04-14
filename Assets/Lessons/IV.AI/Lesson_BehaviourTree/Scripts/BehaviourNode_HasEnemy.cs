using Lessons.AI.HierarchicalStateMachine;
using Lessons.AI.LessonBehaviourTree;
using UnityEngine;

namespace Lessons.AI.Lesson_BehaviourTree
{
    public sealed class BehaviourNode_HasEnemy : BehaviourNode
    {
        [SerializeField]
        private Blackboard blackboard;
        
        protected override void Run()
        {
            var hasEnemy = this.blackboard.HasVariable(BlackboardKeys.ENEMY);
            this.Return(hasEnemy);
        }
    }
}


