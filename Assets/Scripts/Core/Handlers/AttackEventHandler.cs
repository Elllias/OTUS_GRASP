using System;
using Core.Data;
using Core.Events;
using JetBrains.Annotations;
using UnityEngine;
using VContainer.Unity;

namespace Core.Handlers
{
    [UsedImplicitly]
    public class AttackEventHandler : IInitializable, IDisposable
    {
        private readonly EventBus _eventBus;

        public AttackEventHandler(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        void IInitializable.Initialize()
        {
            _eventBus.Subscribe<AttackEvent>(OnAttackEvent);
        }
        
        void IDisposable.Dispose()
        {
            _eventBus.Unsubscribe<AttackEvent>(OnAttackEvent);
        }

        private void OnAttackEvent(AttackEvent evt)
        {
            /*// attack logic
            evt.Source.TakeDamage(evt.Target.Statistics.Damage);
            evt.Target.TakeDamage(evt.Source.Statistics.Damage);
            
            // visual logic
            evt.Source.View.AnimateAttack(evt.Target.View);*/

            /*switch (evt.Source.Type)
            {
                case EHeroType.Devourer:
                    break;
                case EHeroType.Hunter:
                    break;
                case EHeroType.StupidOrk:
                    break;
                case EHeroType.VampLord:
                    break;
                case EHeroType.Paladin:
                    break;
                case EHeroType.IceMage:
                    break;
                case EHeroType.Meditator:
                    break;
                case EHeroType.Electro:
                    break;
                default:
                    throw new NotImplementedException();
            }*/
        }
    }
}