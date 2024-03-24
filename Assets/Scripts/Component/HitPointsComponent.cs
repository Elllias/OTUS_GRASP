using System;
using Interface;
using UnityEngine;

namespace Component
{
    public sealed class HitPointsComponent : MonoBehaviour, IStartListener
    {
        public event Action HitPointsGone;

        [SerializeField] private int _initialHitPoints;

        private int _hitPoints;

        public void OnStart()
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