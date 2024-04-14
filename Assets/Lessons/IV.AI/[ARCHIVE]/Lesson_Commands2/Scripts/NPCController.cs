using System.Linq;
using Entities;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.AI.Lesson_Commands2
{
    public sealed class NPCController : MonoBehaviour
    {
        [SerializeField]
        private MonoEntity entity;

        [Button]
        public void MoveToPosition(Transform point)
        {
            this.entity.Get<IComponent_MoveToPositiion>().Move(point.position);
        }

        [Button]
        public void Attack(IEntity target)
        {
            var operation = new CombatOperation(target);
            this.entity.Get<IComponent_MeleeCombat>().StartCombat(operation);
        }

        [Button]
        public void Patrol(Transform[] points)
        {
            var posiitions = points.Select(it => it.position);
            var operation = new PatrolByPointsOperation(posiitions);
            this.entity.Get<IComponent_PatrolByPoints>().StartPatrol(operation);
        }

        [Button]
        public void Stop()
        {
            this.entity.Get<IComponent_Stop>().Stop();
        }
    }
}