using System;
using System.Collections.Generic;
using System.Linq;
using Core.Data;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

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

            _listView.OnHeroClicked += OnHeroClicked;
        }

        ~HeroesController()
        {
            _listView.OnHeroClicked -= OnHeroClicked;
        }

        public Hero GetNextHero()
        {
            if (!HasAliveHero())
            {
                return null;
            }

            var aliveHeroes = _heroes.Where(hero => hero.IsAlive()).ToList();

            if (aliveHeroes.Count == 0)
            {
                return null;
            }

            _heroIndex %= aliveHeroes.Count;

            var hero = aliveHeroes[_heroIndex];

            _heroIndex = (_heroIndex + 1) % aliveHeroes.Count;

            return hero;
        }

        public Hero GetRandomAliveHero()
        {
            var numberOfAliveBlueHeroes = _heroes.Count(hero => hero.IsAlive());
            var randomIndex = 0;

            if (numberOfAliveBlueHeroes > 1)
            {
                randomIndex = Random.Range(0, numberOfAliveBlueHeroes);
            }

            return _heroes.Where(hero => hero.IsAlive()).ToList()[randomIndex];
        }

        public bool HasAliveHero()
        {
            return _heroes.Any(hero => hero.IsAlive());
        }

        public IEnumerable<Hero> GetAliveHeroes()
        {
            return _heroes.Where(hero => hero.IsAlive()).ToList();
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

        private void OnHeroClicked(HeroView view)
        {
            HeroClicked?.Invoke(_container.GetHero(view));
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