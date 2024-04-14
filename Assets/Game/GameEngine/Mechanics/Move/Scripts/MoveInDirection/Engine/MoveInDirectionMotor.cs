using System;
using System.Collections.Generic;
using Elementary;
using Declarative;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class MoveInDirectionMotor : IMoveInDirectionMotor
    {
        private static readonly Vector3 ZERO_DIRECTION = Vector3.zero;

        public event Action OnStartMove;

        public event Action OnStopMove;

        public bool IsMoving
        {
            get { return this.moveRequired && this.direction != ZERO_DIRECTION; }
        }

        public Vector3 Direction
        {
            get { return this.direction; }
        }

        [ShowInInspector, ReadOnly, PropertyOrder(-11)]
        private bool isEnabled;

        [ShowInInspector, ReadOnly, PropertyOrder(-10)]
        private bool moveRequired;

        [ShowInInspector, ReadOnly, PropertyOrder(-9)]
        private bool finishMove;

        [ShowInInspector, ReadOnly, PropertyOrder(-8)]
        private Vector3 direction;

        [ShowInInspector, ReadOnly, PropertyOrder(-6)]
        private List<ICondition<Vector3>> preconditions = new();

        [ShowInInspector, ReadOnly, PropertyOrder(-5)]
        private List<IAction<Vector3>> startActions = new();

        [ShowInInspector, ReadOnly, PropertyOrder(-4)]
        private List<IAction<Vector3>> stopActions = new();

        public bool CanMove(Vector3 direction)
        {
            for (int i = 0, count = this.preconditions.Count; i < count; i++)
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

        public void Update()
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
        
        public void AddPrecondition(Func<Vector3, bool> condition)
        {
            this.preconditions.Add(new ConditionDelegate<Vector3>(condition));
        }

        public void AddPrecondition(ICondition<Vector3> condition)
        {
            this.preconditions.Add(condition);
        }

        public void AddPreconditions(params ICondition<Vector3>[] conditions)
        {
            this.preconditions.AddRange(conditions);
        }

        public void AddPreconditions(IEnumerable<ICondition<Vector3>> conditions)
        {
            this.preconditions.AddRange(conditions);
        }

        public void RemovePrecondition(ICondition<Vector3> condition)
        {
            this.preconditions.Remove(condition);
        }

        public void AddStartAction(Action<Vector3> action)
        {
            this.startActions.Add(new ActionDelegate<Vector3>(action));
        }

        public void AddStartAction(IAction<Vector3> action)
        {
            this.startActions.Add(action);
        }

        public void AddStartActions(IEnumerable<IAction<Vector3>> actions)
        {
            this.startActions.AddRange(actions);
        }

        public void RemoveStartAction(IAction<Vector3> action)
        {
            this.startActions.Remove(action);
        }

        public void AddStopAction(IAction<Vector3> action)
        {
            this.stopActions.Add(action);
        }

        public void AddStopActions(IEnumerable<IAction<Vector3>> actions)
        {
            this.stopActions.AddRange(actions);
        }

        public void RemoveStopAction(IAction<Vector3> action)
        {
            this.stopActions.Remove(action);
        }

        private void StartMove()
        {
            for (int i = 0, count = this.startActions.Count; i < count; i++)
            {
                var action = this.startActions[i];
                action.Do(this.direction);
            }

            this.OnStartMove?.Invoke();
        }

        private void StopMove()
        {
            for (int i = 0, count = this.stopActions.Count; i < count; i++)
            {
                var action = this.stopActions[i];
                action.Do(this.direction);
            }

            this.OnStopMove?.Invoke();
        }
    }
}