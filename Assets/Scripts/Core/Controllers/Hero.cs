using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data;
using Core.Enum;
using UI;
using UnityEngine;

namespace Core.Controllers
{
    [Serializable]
    public class Hero
    {
        [field: SerializeField] public EHeroType Type { get; private set; }
        [field: SerializeField] public HeroView View { get; private set; }

        [SerializeField] private StatisticsData _statistics;
        [SerializeField] private List<EEffect> _effects;

        public void Construct()
        {
            View.SetStats(_statistics.ToString());
        }

        public void TakeDamage(int damage)
        {
            if (_effects.Contains(EEffect.Protected))
            {
                RemoveEffect(EEffect.Protected);
                return;
            }

            _statistics.Health -= damage;

            if (_statistics.Health <= 0)
            {
                _statistics.Health = 0;
            }

            View.SetStats(_statistics.ToString());
        }

        public void AddEffect(EEffect effect)
        {
            _effects.Add(effect);
        }

        public void RemoveEffect(EEffect effect)
        {
            _effects.Remove(effect);
        }

        public int GetDamage()
        {
            return _statistics.Damage;
        }

        public void AddHealth(int health)
        {
            _statistics.Health += health;

            View.SetStats(_statistics.ToString());
        }

        public void SetViewActive(bool value)
        {
            View.gameObject.SetActive(value);
        }

        public bool IsAlive()
        {
            return _statistics.Health > 0;
        }

        public bool IsFrozen()
        {
            return _effects.Contains(EEffect.Frozen);
        }
    }
}