/*using System;
using JetBrains.Annotations;
using Lessons.Entities.Common.Components;
using Lessons.Game.Events;
using Lessons.Game.Events.Effects;
using VContainer.Unity;

namespace Lessons.Game.Handlers.Effects
{
    [UsedImplicitly]
    public class DealDamageEffectHandler : IInitializable, IDisposable
    {
        private readonly EventBus _eventBus;

        public DealDamageEffectHandler(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        void IInitializable.Initialize()
        {
            _eventBus.Subscribe<DealDamageEffectEvent>(OnDealDamage);
        }

        void IDisposable.Dispose()
        {
            _eventBus.Unsubscribe<DealDamageEffectEvent>(OnDealDamage);
        }

        private void OnDealDamage(DealDamageEffectEvent evt)
        {
            int strength = evt.ExtraDamage;
            if (evt.Source.TryGet(out StatsComponent statsComponent))
            {
                strength += statsComponent.Strength;
            }
            
            _eventBus.RaiseEvent(new DealDamageEvent(evt.Target, strength));
        }
    }
}*/