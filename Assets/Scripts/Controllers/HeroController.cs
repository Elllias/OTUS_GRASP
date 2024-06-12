using System;
using Data;
using UI;
using UnityEngine;

namespace Controllers
{
    [Serializable]
    public class HeroController
    {
        public event Action Clicked;
        
        [SerializeField] private StatisticsData _statisticsData;
        [SerializeField] private HeroView _heroView;
        
        private HeroViewController _heroViewController;

        public void Construct()
        {
            _heroViewController = new HeroViewController(_heroView);
            
            _heroViewController.Clicked += OnClicked;
        }

        public void Release()
        {
            _heroViewController.Clicked -= OnClicked;
        }

        private void OnClicked()
        {
            Clicked?.Invoke();
        }
    }
}