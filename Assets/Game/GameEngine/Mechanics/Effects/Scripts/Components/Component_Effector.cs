using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_Effector : IComponent_Effector
    {
        public event Action<IEffect> OnApplied
        {
            add { this.effector.OnApplied += value; }
            remove { this.effector.OnApplied -= value; }
        }

        public event Action<IEffect> OnDiscarded
        {
            add { this.effector.OnDiscarded += value; }
            remove { this.effector.OnDiscarded -= value; }
        }

        private readonly IEffector<IEffect> effector;

        public Component_Effector(IEffector<IEffect> effector)
        {
            this.effector = effector;
        }

        public void Apply(IEffect effect)
        {
            this.effector.Apply(effect);
        }

        public void Discard(IEffect effect)
        {
            this.effector.Discard(effect);
        }
    }
}