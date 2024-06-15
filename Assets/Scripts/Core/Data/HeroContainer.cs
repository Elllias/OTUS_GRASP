using System;
using System.Collections.Generic;
using System.Linq;
using UI;
using UnityEngine;

namespace Core.Data
{
    public class HeroContainer : MonoBehaviour
    {
        [SerializeField] private List<Hero> _heroes;
        
        public Hero GetHero(HeroView view)
        {
            var hero = _heroes.FirstOrDefault(v => v.View == view);

            if (hero == null)
            {
                Debug.LogError($"Hero {view} not found");
                return null;
            }
            
            hero.Construct();
            
            return hero;
        }
    }

    [Serializable]
    public abstract class Hero
    {
        public event Action<Hero> Dead;

        public HeroView View;
        public StatisticsData Statistics;

        public void Construct()
        {
            View.SetStats(Statistics.ToString());
        }

        public void TakeDamage(int damage)
        {
            Statistics.Health -= damage;

            if (Statistics.Health <= 0)
            {
                Statistics.Health = 0;
                Dead?.Invoke(this);
            }
            
            View.SetStats(Statistics.ToString());
        }
    }
}