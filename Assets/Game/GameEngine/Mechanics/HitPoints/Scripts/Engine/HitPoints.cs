using System;
using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class HitPoints : IHitPoints
    {
        public event Action OnSetuped;

        public event Action<int> OnCurrentPointsChanged;

        public event Action<int> OnMaxPointsChanged;

        private ActionComposite setupActions;

        private ActionComposite<int> onCurrentPointsChanged;

        private ActionComposite<int> onMaxPointsChanged;

        public int Current
        {
            get { return this.currentHitPoints; }
            set { this.SetCurrentPoints(value); }
        }

        public int Max
        {
            get { return this.maxHitPoints; }
            set { this.SetMaxPoints(value); }
        }

        [SerializeField, OnValueChanged("SetMaxPoints")]
        private int maxHitPoints;

        [SerializeField, OnValueChanged("SetCurrentPoints")]
        private int currentHitPoints;

        [Title("Methods")]
        [GUIColor(0, 1, 0)]
        [Button]
        public void Setup(int current, int max)
        {
            this.maxHitPoints = max;
            this.currentHitPoints = Mathf.Clamp(current, 0, this.maxHitPoints);

            this.setupActions?.Do();
            this.OnSetuped?.Invoke();
        }

        private void SetCurrentPoints(int value)
        {
            value = Mathf.Clamp(value, 0, this.maxHitPoints);
            this.currentHitPoints = value;

            this.onCurrentPointsChanged?.Do(value);
            this.OnCurrentPointsChanged?.Invoke(value);
        }

        private void SetMaxPoints(int value)
        {
            value = Math.Max(1, value);
            if (this.currentHitPoints > value)
            {
                this.currentHitPoints = value;
            }

            this.maxHitPoints = value;

            this.onMaxPointsChanged?.Do(value);
            this.OnMaxPointsChanged?.Invoke(value);
        }

        public IAction<int> AddCurrentListener(Action<int> action)
        {
            var actionDelegate = new ActionDelegate<int>(action);
            this.onCurrentPointsChanged += actionDelegate;
            return actionDelegate;
        }

        public IAction<int> AddMaxListener(Action<int> action)
        {
            var actionDelegate = new ActionDelegate<int>(action);
            this.onMaxPointsChanged += actionDelegate;
            return actionDelegate;
        }

        public IAction AddSetupListener(Action action)
        {
            var actionDelegate = new ActionDelegate(action);
            this.setupActions += actionDelegate;
            return actionDelegate;
        }

        public void AddCurrentListener(IAction<int> action)
        {
            this.onCurrentPointsChanged += action;
        }

        public void AddMaxListener(IAction<int> action)
        {
            this.onMaxPointsChanged += action;
        }

        public void AddSetupListener(IAction action)
        {
            this.setupActions += action;
        }

        public void RemoveCurrentListener(IAction<int> action)
        {
            this.onCurrentPointsChanged -= action;
        }

        public void RemoveMaxListener(IAction<int> action)
        {
            this.onMaxPointsChanged -= action;
        }

        public void RemoveSetupListener(IAction action)
        {
            this.setupActions -= action;
        }
    }
}