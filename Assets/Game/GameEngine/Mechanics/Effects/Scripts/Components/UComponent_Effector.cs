using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Effects/Component «Effector»")]
    public sealed class UComponent_Effector : MonoBehaviour, IComponent_Effector
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

        [SerializeField]
        private UEffector effector;
        
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