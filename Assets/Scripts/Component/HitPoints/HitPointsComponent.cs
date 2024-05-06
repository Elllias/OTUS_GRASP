using System;
using Core;
using Interface;
using UnityEngine;
using VContainer;

namespace Component.HitPoints
{
    public class HitPointsComponent : MonoBehaviour
    {
        [SerializeField] private int _initialHitPoints;
        
        private HitPointsController _controller;
        
        public void Construct(GameManager gameManager)
        {
            _controller = new HitPointsController(_initialHitPoints, gameManager);
        }

        public HitPointsController GetController()
        {
            return _controller;
        }
    }
}