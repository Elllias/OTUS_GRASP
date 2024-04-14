using System;
using System.Collections.Generic;
using Elementary;
using Sirenix.OdinInspector;

namespace Game.GameEngine.Mechanics
{
    public sealed class PatrolByPointsEngine : IPatrolByPointsEngine
    {
        public event Action<PatrolByPointsOperation> OnPatrolStarted;

        public event Action<PatrolByPointsOperation> OnPatrolStopped;

        [ShowInInspector, ReadOnly, PropertyOrder(-10), PropertySpace]
        public bool IsPatrol { get; private set; }

        [ShowInInspector, ReadOnly, PropertyOrder(-9)]
        public PatrolByPointsOperation CurrentOperation { get; private set; }

        [ShowInInspector, ReadOnly, PropertyOrder(-8), PropertySpace]
        private List<ICondition<PatrolByPointsOperation>> preconditions = new();

        [ShowInInspector, ReadOnly, PropertyOrder(-7)]
        private List<IAction<PatrolByPointsOperation>> startActions = new();

        [ShowInInspector, ReadOnly, PropertyOrder(-6)]
        private List<IAction<PatrolByPointsOperation>> stopActions = new();

        [Title("Methods")]
        [Button]
        public bool CanStartPatrol(PatrolByPointsOperation operation)
        {
            if (this.IsPatrol)
            {
                return false;
            }

            for (int i = 0, count = this.preconditions.Count; i < count; i++)
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

            for (int i = 0, count = this.startActions.Count; i < count; i++)
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
            for (int i = 0, count = this.stopActions.Count; i < count; i++)
            {
                var action = this.stopActions[i];
                action.Do(operation);
            }

            this.IsPatrol = false;
            this.CurrentOperation = default;
            this.OnPatrolStopped?.Invoke(operation);
        }

        public void AddPreconditions(params ICondition<PatrolByPointsOperation>[] conditions)
        {
            this.preconditions.AddRange(conditions);
        }

        public void AddPreconditions(IEnumerable<ICondition<PatrolByPointsOperation>> conditions)
        {
            this.preconditions.AddRange(conditions);
        }

        public void AddPreconditon(ICondition<PatrolByPointsOperation> condition)
        {
            this.preconditions.Add(condition);
        }

        public void AddStartActions(IEnumerable<IAction<PatrolByPointsOperation>> actions)
        {
            this.startActions.AddRange(actions);
        }

        public void AddStartAction(IAction<PatrolByPointsOperation> action)
        {
            this.startActions.Add(action);
        }

        public void AddStopActions(IEnumerable<IAction<PatrolByPointsOperation>> actions)
        {
            this.stopActions.AddRange(actions);
        }

        public void AddStopAction(IAction<PatrolByPointsOperation> action)
        {
            this.stopActions.Add(action);
        }
    }
}