using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Hit Points/Hit Points")]
    public sealed class UHitPoints : MonoBehaviour, IHitPoints
    {
        public event Action OnSetuped; 

        public event Action<int> OnCurrentPointsChanged;

        public event Action<int> OnMaxPointsChanged;

        public event Action OnCurrentPointsFull;

        public event Action OnCurrentPointsOver;

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

        [SerializeField]
        private int maxHitPoints;

        [SerializeField]
        private int currentHitPoints;

        [Title("Methods")]
        [GUIColor(0, 1, 0)]
        [Button]
        public void Setup(int current, int max)
        {
            this.maxHitPoints = max;
            this.currentHitPoints = Mathf.Clamp(current, 0, this.maxHitPoints);
            this.OnSetuped?.Invoke();
        }

        [GUIColor(0, 1, 0)]
        [Button]
        private void SetCurrentPoints(int value)
        {
            value = Mathf.Clamp(value, 0, this.maxHitPoints);
            this.currentHitPoints = value;
            this.OnCurrentPointsChanged?.Invoke(this.currentHitPoints);

            if (value <= 0)
            {
                this.OnCurrentPointsOver?.Invoke();
            }

            if (value >= this.maxHitPoints)
            {
                this.OnCurrentPointsFull?.Invoke();
            }
        }

        [Button]
        [GUIColor(0, 1, 0)]
        private void SetMaxPoints(int value)
        {
            value = Math.Max(1, value);
            if (this.currentHitPoints > value)
            {
                this.currentHitPoints = value;
            }

            this.maxHitPoints = value;
            this.OnMaxPointsChanged?.Invoke(value);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            this.maxHitPoints = Math.Max(1, this.maxHitPoints);
            this.currentHitPoints = Mathf.Clamp(this.currentHitPoints, 1, this.maxHitPoints);
        }
#endif
    }
}