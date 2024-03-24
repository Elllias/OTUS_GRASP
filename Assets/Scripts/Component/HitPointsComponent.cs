using System;
using UnityEngine;

namespace Component
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action HitPointsGone;

        [SerializeField] private int _initialHitPoints;

        private int _hitPoints;

        private void Start()
        {
            Reset();
        }

        public void Reset()
        {
            _hitPoints = _initialHitPoints;
        }

        public void TakeDamage(int damage)
        {
            _hitPoints -= damage;

            if (_hitPoints <= 0)
            {
                HitPointsGone?.Invoke();
            }
        }
    }
}