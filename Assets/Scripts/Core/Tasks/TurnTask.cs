using System;
using Core.Controllers;
using Core.Data;
using Core.Enum;
using Core.Events;
using UI;

namespace Core.Tasks
{
    public class TurnTask : Task
    {
        private readonly EventBus _eventBus;
        private readonly Func<Hero> _heroFunc;
        private readonly HeroesController _targetHeroesController;

        private Hero _hero;

        public TurnTask(EventBus eventBus, Func<Hero> heroFunc, HeroesController targetHeroesController)
        {
            _eventBus = eventBus;
            _heroFunc = heroFunc;
            _targetHeroesController = targetHeroesController;
        }
        
        protected override void OnRun()
        {
            _hero = _heroFunc.Invoke();

            if (_hero == null)
            {
                Finish();
                return;
            }

            if (_hero.IsFrozen())
            {
                _hero.RemoveEffect(EEffect.Frozen);
                Finish();
                return;
            }

            if (!_targetHeroesController.HasAliveHero())
            {
                Finish();
                return;
            }
            
            _hero.View.SetActive(true);
            
            _targetHeroesController.HeroClicked += TargetHeroClicked;
        }

        protected override void OnFinish()
        {
            if (_hero == null)
            {
                return;
            }
            
            _hero.View.SetActive(false);
            
            _targetHeroesController.HeroClicked -= TargetHeroClicked;
        }

        private void TargetHeroClicked(Hero targetHero)
        {
            _eventBus.RaiseEvent(new AttackEvent(_hero, targetHero));
            
            Finish();
        }
    }
}