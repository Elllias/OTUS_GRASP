using System;
using Core;
using Events;
using JetBrains.Annotations;
using VContainer.Unity;

namespace Handlers
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
            // attack logic
            // visual logic
        }
    }
}