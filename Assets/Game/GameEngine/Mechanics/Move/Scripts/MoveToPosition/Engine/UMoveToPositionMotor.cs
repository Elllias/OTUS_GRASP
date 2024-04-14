using System;
using Game.GameEngine.Mechanics.Move;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Move/Move To Position Motor")]
    public sealed class UMoveToPositionMotor : MonoBehaviour, IMoveToPositionMotor
    {
        public event Action<Vector3> OnMoveStarted;

        public event Action<Vector3> OnMoveStopped;

        [ShowInInspector, ReadOnly, PropertyOrder(-10), PropertySpace]
        public bool IsMove { get; private set; }

        [ShowInInspector, ReadOnly, PropertyOrder(-9)]
        public Vector3 TargetPosition { get; private set; }

        [SerializeField]
        private UMoveToPositionCondition[] preconditions;

        [SerializeField]
        private UMoveToPositionAction[] startActions;

        [SerializeField]
        private UMoveToPositionAction[] stopActions;

        [Title("Methods")]
        [Button]
        public bool CanStartMove(Vector3 operation)
        {
            if (this.IsMove)
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
        public void StartMove(Vector3 operation)
        {
            if (!this.CanStartMove(operation))
            {
                return;
            }

            for (int i = 0, count = this.startActions.Length; i < count; i++)
            {
                var action = this.startActions[i];
                action.Do(operation);
            }

            this.TargetPosition = operation;
            this.IsMove = true;
            this.OnMoveStarted?.Invoke(operation);
        }

        [Button]
        public void StopMove()
        {
            if (!this.IsMove)
            {
                return;
            }

            var operation = this.TargetPosition;
            for (int i = 0, count = this.stopActions.Length; i < count; i++)
            {
                var action = this.stopActions[i];
                action.Do(operation);
            }

            this.IsMove = false;
            this.TargetPosition = default;
            this.OnMoveStopped?.Invoke(operation);
        }
    }
}