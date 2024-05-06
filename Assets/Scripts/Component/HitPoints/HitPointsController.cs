using System;
using Core;
using Interface;
using UnityEngine;
using VContainer;

namespace Component.HitPoints
{
    public class HitPointsController : IStartListener
    {
        public event Action HitPointsGone;

        private readonly int _initialHitPoints;
        private readonly GameManager _gameManager;
        
        private int _hitPoints;

        public HitPointsController(int initialHitPoints, GameManager gameManager)
        {
            _initialHitPoints = initialHitPoints;
            _gameManager = gameManager;
            
            _gameManager.AddStartListener(this);
        }

        ~HitPointsController()
        {
            _gameManager.RemoveStartListener(this);
        }
        
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