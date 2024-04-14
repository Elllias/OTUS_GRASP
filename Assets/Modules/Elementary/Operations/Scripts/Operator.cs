using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Elementary
{
    [Serializable]
    public sealed class Operator<T> : IOperator<T>
    {
        public event Action<T> OnStarted;

        public event Action<T> OnStopped;

        private ActionComposite<T> onStarted;

        private ActionComposite<T> onStopped;

        [ShowInInspector, ReadOnly]
        public bool IsActive
        {
            get { return this.Current != null; }
        }

        [ShowInInspector, ReadOnly]
        public T Current { get; private set; }

        private ConditionComposite<T> conditions;

        private ActionComposite<T> startActions;

        private ActionComposite<T> stopActions;

        [Title("Methods")]
        [Button]
        public bool CanStart(T operation)
        {
            if (this.IsActive)
            {
                return false;
            }

            if (this.conditions == null)
            {
                return true;
            }

            return this.conditions.IsTrue(operation);
        }

        [Button]
        public void DoStart(T operation)
        {
            if (!this.CanStart(operation))
            {
                return;
            }

            this.Current = operation;
            this.startActions?.Do(operation);
            this.OnStarted?.Invoke(operation);
        }

        [Button]
        public void Stop()
        {
            if (!this.IsActive)
            {
                return;
            }

            var operation = this.Current;

            this.Current = default;
            this.stopActions?.Do(operation);
            this.OnStopped?.Invoke(operation);
        }

        public void AddConditions(params ICondition<T>[] conditions)
        {
            this.conditions += conditions;
        }

        public void AddConditions(IEnumerable<ICondition<T>> conditions)
        {
            this.conditions += conditions;
        }

        public ICondition<T> AddCondition(Func<T, bool> condition)
        {
            var conditionDelegate = new ConditionDelegate<T>(condition);
            this.conditions += conditionDelegate;
            return conditionDelegate;
        }

        public void AddCondition(ICondition<T> condition)
        {
            this.conditions += condition;
        }

        public void RemoveCondition(ICondition<T> condition)
        {
            this.conditions -= condition;
        }

        public void AddStartActions(params IAction<T>[] actions)
        {
            this.startActions += actions;
        }

        public void AddStartActions(IEnumerable<IAction<T>> actions)
        {
            this.startActions += actions;
        }

        public ActionDelegate<T> AddStartAction(Action<T> action)
        {
            var actionDelegate = new ActionDelegate<T>(action);
            this.startActions += actionDelegate;
            return actionDelegate;
        }

        public void AddStartAction(IAction<T> action)
        {
            this.startActions += action;
        }
        
        public void RemoveStartAction(IAction<T> action)
        {
            this.startActions -= action;
        }

        public void AddStopActions(IEnumerable<IAction<T>> actions)
        {
            this.stopActions += actions;
        }

        public void AddStopAction(IAction<T> action)
        {
            this.stopActions += action;
        }
        
        public ActionDelegate<T> AddStopAction(Action<T> action)
        {
            var actionDelegate = new ActionDelegate<T>(action);
            this.stopActions += actionDelegate;
            return actionDelegate;
        }
        
        public void RemoveStopAction(IAction<T> action)
        {
            this.stopActions -= action;
        }
    }
}