using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data;
using UI;
using UnityEngine;

namespace Core.Controllers
{
    public abstract class HeroesController
    {
        public event Action<Hero> HeroClicked;
        
        private readonly HeroListView _listView;
        private readonly HeroContainer _container;
        private readonly IReadOnlyList<Hero> _heroes;

        private int _heroIndex;
        
        protected HeroesController(HeroListView listView, HeroContainer container)
        {
            _listView = listView;
            _container = container;
            _heroes = GetHeroes(listView.GetViews());

            InitializeHeroes();
            
            _listView.OnHeroClicked += OnHeroClicked;
        }

        ~HeroesController()
        {
            _listView.OnHeroClicked -= OnHeroClicked;
            DeinitializeHeroes();
        }

        public Hero GetNextHero()
        {
            if (!HasAliveHero())
            {
                return null;
            }
    
            var aliveHeroes = _heroes.Where(hero => hero.Statistics.Health > 0).ToList();
    
            if (aliveHeroes.Count == 0)
            {
                return null;
            }

            // Корректировка индекса
            _heroIndex %= aliveHeroes.Count;
    
            var hero = aliveHeroes[_heroIndex];
    
            _heroIndex = (_heroIndex + 1) % aliveHeroes.Count;

            return hero;
        }


        public bool HasAliveHero()
        {
            return _heroes.Any(hero => hero.Statistics.Health > 0);
        }

        private IReadOnlyList<Hero> GetHeroes(IReadOnlyList<HeroView> views)
        {
            var heroes = new List<Hero>();

            for (int i = 0; i < views.Count(); i++)
            {
                heroes.Add(_container.GetHero(views[i]));
            }

            return heroes;
        }

        private void InitializeHeroes()
        {
            for (int i = 0; i < _heroes.Count; i++)
            {
                _heroes[i].Dead += OnHeroDead;
            }
        }

        private void DeinitializeHeroes()
        {
            for (int i = 0; i < _heroes.Count; i++)
            {
                _heroes[i].Dead -= OnHeroDead;
            }
        }

        private void OnHeroClicked(HeroView view)
        {
            HeroClicked?.Invoke(_container.GetHero(view));
        }

        private void OnHeroDead(Hero hero)
        {
            hero.Dead -= OnHeroDead;
            hero.View.gameObject.SetActive(false);
        }
    }

    public class BlueHeroesController : HeroesController
    {
        public BlueHeroesController(HeroListView listView, HeroContainer container) : base(listView, container) { }
    }
    
    public class RedHeroesController : HeroesController
    {
        public RedHeroesController(HeroListView listView, HeroContainer container) : base(listView, container) { }
    }
}