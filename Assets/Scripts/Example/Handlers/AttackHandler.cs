/*using System;
using JetBrains.Annotations;
using Lessons.Entities.Common.Components;
using Lessons.Game.Events;
using VContainer.Unity;

namespace Lessons.Game.Handlers
{
    [UsedImplicitly]
    public class AttackHandler : IInitializable, IDisposable
    {
        private readonly EventBus _eventBus;

        public AttackHandler(EventBus eventBus)
        {
            _eventBus = eventBus;
        }
        
        void IInitializable.Initialize()
        {
            _eventBus.Subscribe<AttackEvent>(OnAttack);
        }

        void IDisposable.Dispose()
        {
            _eventBus.Unsubscribe<AttackEvent>(OnAttack);
        }

        private void OnAttack(AttackEvent evt)
        {
            if (evt.Entity.TryGet(out WeaponComponent weaponComponent))
            {
                foreach (var effect in weaponComponent.Value.Effects)
                {
                    effect.Source = evt.Entity;
                    effect.Target = evt.Target;
                    
                    _eventBus.RaiseEvent(effect);
                }
            }
        }
    }
}*/