using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Move/Move In Direction Motor")]
    public sealed class UMoveInDirectionMotor : MonoBehaviour, IMoveInDirectionMotor
    {
        private static readonly Vector3 ZERO_DIRECTION = Vector3.zero;

        public event Action OnStartMove;

        public event Action OnStopMove;

        public bool IsMoving
        {
            get { return this.moveRequired && this.direction != ZERO_DIRECTION; }
        }

        public bool IsEnabled
        {
            get { return this.enabled; }
            set { this.enabled = value; }
        }

        public Vector3 Direction
        {
            get { return this.direction; }
        }

        [PropertyOrder(-10)]
        [ReadOnly]
        [ShowInInspector]
        private bool moveRequired;

        [PropertyOrder(-9)]
        [ReadOnly]
        [ShowInInspector]
        private bool finishMove;

        [PropertyOrder(-8)]
        [ReadOnly]
        [ShowInInspector]
        private Vector3 direction;

        [Space]
        [SerializeField]
        private UpdateMode updateMode;

        [Space]
        [SerializeField]
        private UMoveInDirecitonCondition[] preconditions;

        [SerializeField]
        private UMoveInDirectionAction[] startActions;

        [SerializeField]
        private UMoveInDirectionAction[] stopActions;

        private void FixedUpdate()
        {
            if (this.updateMode == UpdateMode.FIXED_UPDATE)
            {
                this.UpdateMove();
            }
        }

        private void Update()
        {
            if (this.updateMode == UpdateMode.UPDATE)
            {
                this.UpdateMove();
            }
        }

        public bool CanMove(Vector3 direction)
        {
            for (int i = 0, count = this.preconditions.Length; i < count; i++)
            {
                var condition = this.preconditions[i];
                if (!condition.IsTrue(direction))
                {
                    return false;
                }
            }

            return true;
        }

        public void RequestMove(Vector3 direction)
        {
            if (!this.CanMove(direction))
            {
                return;
            }

            this.direction = direction;
            this.finishMove = false;

            if (!this.moveRequired)
            {
                this.moveRequired = true;
                this.StartMove();
            }
        }

        public void Interrupt()
        {
            if (!this.moveRequired)
            {
                return;
            }

            this.finishMove = false;
            this.moveRequired = false;
            this.StopMove();
        }

        private void StartMove()
        {
            for (int i = 0, count = this.startActions.Length; i < count; i++)
            {
                var action = this.startActions[i];
                action.Do(this.direction);
            }

            this.OnStartMove?.Invoke();
        }

        private void UpdateMove()
        {
            if (!this.moveRequired)
            {
                return;
            }

            if (this.finishMove)
            {
                this.moveRequired = false;
                this.StopMove();
            }

            this.finishMove = true;
        }

        private void StopMove()
        {
            for (int i = 0, count = this.stopActions.Length; i < count; i++)
            {
                var action = this.stopActions[i];
                action.Do(this.direction);
            }

            this.OnStopMove?.Invoke();
        }

        private enum UpdateMode
        {
            UPDATE = 0,
            FIXED_UPDATE = 1
        }
    }
}