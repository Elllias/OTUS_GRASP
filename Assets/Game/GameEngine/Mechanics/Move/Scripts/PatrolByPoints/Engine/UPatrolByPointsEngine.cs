using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Move/Patrol By Points Engine")]
    public sealed class UPatrolByPointsEngine : MonoBehaviour, IPatrolByPointsEngine
    {
        public event Action<PatrolByPointsOperation> OnPatrolStarted;

        public event Action<PatrolByPointsOperation> OnPatrolStopped;

        [ShowInInspector, ReadOnly, PropertyOrder(-10), PropertySpace]
        public bool IsPatrol { get; private set; }

        [ShowInInspector, ReadOnly, PropertyOrder(-9)]
        public PatrolByPointsOperation CurrentOperation { get; private set; }

        [SerializeField]
        private UPatrolByPointsCondition[] preconditions;

        [SerializeField]
        private UPatrolByPointsAction[] startActions;

        [SerializeField]
        private UPatrolByPointsAction[] stopActions;

        [Title("Methods")]
        [Button]
        public bool CanStartPatrol(PatrolByPointsOperation operation)
        {
            if (this.IsPatrol)
            {
                return false;
            }

            for (int i = 0, count = this.preconditions.Length; i < count; i++)
            {
                var condition = this.preconditions[i];
                if (!condition.IsTrue(operation))
                {
                    return false;
                }
            }

            return true;
        }

        [Button]
        public void StartPatrol(PatrolByPointsOperation operation)
        {
            if (!this.CanStartPatrol(operation))
            {
                return;
            }

            for (int i = 0, count = this.startActions.Length; i < count; i++)
            {
                var action = this.startActions[i];
                action.Do(operation);
            }

            this.CurrentOperation = operation;
            this.IsPatrol = true;
            this.OnPatrolStarted?.Invoke(operation);
        }

        [Button]
        public void StopPatrol()
        {
            if (!this.IsPatrol)
            {
                return;
            }

            var operation = this.CurrentOperation;
            for (int i = 0, count = this.stopActions.Length; i < count; i++)
            {
                var action = this.stopActions[i];
                action.Do(operation);
            }

            this.IsPatrol = false;
            this.CurrentOperation = default;
            this.OnPatrolStopped?.Invoke(operation);
        }
    }
}