using System.Collections;
using Entities;
using Game.GameEngine.Mechanics;
using Lessons.AI.HierarchicalStateMachine;
using Lessons.AI.LessonBehaviourTree;
using UnityEngine;

namespace Lessons.AI.Lesson_BehaviourTree
{
    public sealed class BehaviourNode_MoveToEnemy : BehaviourNode, IBehaviourCallback
    {
        [SerializeField]
        private Blackboard blackboard;
        
        [SerializeField]
        private BehaviourNode_MoveToPosition moveNode;

        private Coroutine coroutine;
        
        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(BlackboardKeys.ENEMY, out IEntity enemy))
            {
                this.Return(false);
                return;
            }

            this.coroutine = this.StartCoroutine(this.UpdateEnemyPosition(enemy));
            this.moveNode.Run(callback: this);
        }

        protected override void OnAbort()
        {
            if (this.moveNode.IsRunning)
            {
                this.moveNode.Abort();
            }
        }

        protected override void OnDispose()
        {
            if (this.coroutine != null)
            {
                this.StopCoroutine(this.coroutine);
            }
            
            this.blackboard.RemoveVariable(BlackboardKeys.MOVE_POSITION);
        }

        private IEnumerator UpdateEnemyPosition(IEntity enemy)
        {
            IComponent_GetPosition enemyComponent = enemy.Get<IComponent_GetPosition>();
            var period = new WaitForSeconds(0.2f);

            while (true)
            {
                var enemyPosition = enemyComponent.Position;
                this.blackboard.SetVariable(BlackboardKeys.MOVE_POSITION, enemyPosition);
                yield return period;
            }
        }

        void IBehaviourCallback.Invoke(BehaviourNode node, bool success)
        {
            this.Return(success);
        }
    }
}