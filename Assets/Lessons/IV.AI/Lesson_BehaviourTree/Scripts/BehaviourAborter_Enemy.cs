using System;
using Lessons.AI.HierarchicalStateMachine;
using Lessons.AI.LessonBehaviourTree;
using UnityEngine;

namespace Lessons.AI.Lesson_BehaviourTree
{
    public sealed class BehaviourAborter_Enemy : MonoBehaviour
    {
        [SerializeField]
        private Blackboard blackboard;

        [SerializeField]
        private BehaviourNode rootNode;

        private void OnEnable()
        {
            this.blackboard.OnVariableChanged += this.OnVariableChanged;
            this.blackboard.OnVariableRemoved += this.OnVariableChanged;
        }
        
        private void OnDisable()
        {
            this.blackboard.OnVariableChanged -= this.OnVariableChanged;
            this.blackboard.OnVariableRemoved -= this.OnVariableChanged;
        }

        private void OnVariableChanged(string name, object value)
        {
            if (name == BlackboardKeys.ENEMY)
            {
                this.rootNode.Abort();
            }
        }
    }
}