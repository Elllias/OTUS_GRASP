using System;
using Core.Controllers;
using Core.Data;
using Core.Enum;
using Core.Events;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Sirenix.Utilities;
using UnityEngine;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace Core.Handlers
{
    [UsedImplicitly]
    public class AttackEventHandler : IInitializable, IDisposable
    {
        private readonly EventBus _eventBus;
        private readonly BlueHeroesController _blueHeroesController;
        private readonly RedHeroesController _redHeroesController;

        public AttackEventHandler(
            EventBus eventBus, 
            BlueHeroesController blueHeroesController, 
            RedHeroesController redHeroesController)
        {
            _eventBus = eventBus;
            _blueHeroesController = blueHeroesController;
            _redHeroesController = redHeroesController;
        }

        void IInitializable.Initialize()
        {
            _eventBus.Subscribe<AttackEvent>(OnAttackEvent);
        }
        
        void IDisposable.Dispose()
        {
            _eventBus.Unsubscribe<AttackEvent>(OnAttackEvent);
        }

        private async void OnAttackEvent(AttackEvent evt)
        {
            if (evt.Source.Type == EHeroType.Electro)
            {
                TakeDamageToAllHeroes(1);
            }
            
            switch (evt.Source.Type)
            {
                case EHeroType.Devourer:
                {
                    await DevourerAttack(evt);
                    break;
                }
                case EHeroType.Hunter:
                {
                    await HunterAttack(evt);
                    break;
                }
                case EHeroType.StupidOrk:
                {
                    await StupidOrkAttack(evt);
                    break;
                }
                case EHeroType.LordVamp:
                {
                    await LordVampAttack(evt);
                    break;
                }
                case EHeroType.Paladin:
                {
                    await PaladinAttack(evt);
                    break;
                }
                case EHeroType.IceMage:
                {
                    await IceMageAttack(evt);
                    break;
                }
                case EHeroType.Meditator:
                {
                    await MeditatorAttack(evt);
                    break;
                }
                case EHeroType.Electro:
                {
                    await ElectroAttack(evt);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            evt.Target.SetViewActive(evt.Target.IsAlive());
            evt.Source.SetViewActive(evt.Source.IsAlive());
        }

        private static async UniTask ElectroAttack(AttackEvent evt)
        {
            evt.Target.TakeDamage(evt.Source.GetDamage());
            evt.Source.TakeDamage(evt.Target.GetDamage());
                    
            await evt.Source.View.AnimateAttack(evt.Target.View);
        }

        private async UniTask MeditatorAttack(AttackEvent evt)
        {
            evt.Target.TakeDamage(evt.Source.GetDamage());
            evt.Source.TakeDamage(evt.Target.GetDamage());

            var randomTeammate = _blueHeroesController.GetRandomAliveHero();
            randomTeammate.AddHealth(1);
                    
            await evt.Source.View.AnimateAttack(evt.Target.View);
            await evt.Source.View.AnimateAttack(randomTeammate.View);
        }

        private static async UniTask IceMageAttack(AttackEvent evt)
        {
            evt.Target.TakeDamage(evt.Source.GetDamage());
            evt.Source.TakeDamage(evt.Target.GetDamage());
                    
            evt.Target.AddEffect(EEffect.Frozen);
                    
            await evt.Source.View.AnimateAttack(evt.Target.View);
        }

        private static async UniTask PaladinAttack(AttackEvent evt)
        {
            evt.Target.TakeDamage(evt.Source.GetDamage());
            evt.Source.TakeDamage(evt.Target.GetDamage());
                    
            await evt.Source.View.AnimateAttack(evt.Target.View);
        }

        private static async UniTask LordVampAttack(AttackEvent evt)
        {
            evt.Target.TakeDamage(evt.Source.GetDamage());
            evt.Source.TakeDamage(evt.Target.GetDamage());
                    
            var randomPercent = Random.Range(0f, 1f);

            if (randomPercent <= 0.5f)
            {
                evt.Source.AddHealth(evt.Source.GetDamage());
            }
                    
            await evt.Source.View.AnimateAttack(evt.Target.View);
        }

        private async UniTask StupidOrkAttack(AttackEvent evt)
        {
            var randomPercent = Random.Range(0f, 1f);

            if (randomPercent <= 0.5f)
            {
                evt.Target.TakeDamage(evt.Source.GetDamage());
                evt.Source.TakeDamage(evt.Target.GetDamage());
                    
                await evt.Source.View.AnimateAttack(evt.Target.View);
            }
            else
            {
                var target = _blueHeroesController.GetRandomAliveHero();
                    
                if (evt.Source.Type == EHeroType.Electro)
                {
                    TakeDamageToAllHeroes(1);
                }
                        
                target.TakeDamage(evt.Source.GetDamage());
                evt.Source.TakeDamage(target.GetDamage());
                        
                await evt.Source.View.AnimateAttack(evt.Target.View);
                        
                target.SetViewActive(target.IsAlive());
            }
        }

        private static async UniTask HunterAttack(AttackEvent evt)
        {
            evt.Target.TakeDamage(evt.Source.GetDamage());

            await evt.Source.View.AnimateAttack(evt.Target.View);
        }

        private async UniTask DevourerAttack(AttackEvent evt)
        {
            evt.Target.TakeDamage(evt.Source.GetDamage());
            evt.Source.TakeDamage(evt.Target.GetDamage());
                    
            await evt.Source.View.AnimateAttack(evt.Target.View);
                    
            var randomEnemy = _blueHeroesController.GetRandomAliveHero();
                    
            randomEnemy.TakeDamage(3);
                    
            await evt.Source.View.AnimateAttack(randomEnemy.View);
                    
            if (evt.Source.Type == EHeroType.Electro)
            {
                TakeDamageToAllHeroes(1);
            }
        }

        private void TakeDamageToAllHeroes(int damage)
        {
            _blueHeroesController.GetAliveHeroes().ForEach(hero =>
            {
                hero.TakeDamage(damage);
                hero.SetViewActive(hero.IsAlive());
            });
            _redHeroesController.GetAliveHeroes().ForEach(hero => 
            {
                hero.TakeDamage(damage);
                hero.SetViewActive(hero.IsAlive());
            });
        }
    }
}