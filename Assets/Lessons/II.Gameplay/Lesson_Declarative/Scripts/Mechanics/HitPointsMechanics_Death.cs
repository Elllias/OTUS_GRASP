using Elementary;
using Declarative;
using UnityEngine;

namespace Lessons.Architecture.Declarative.Mechanics
{
    public sealed class HitPointsMechanics_Death : IEnableListener, IDisableListener
    {
        private IVariable<int> hitPoints;

        private IEmitter deathEvent;

        public void Construct(IVariable<int> hitPoints, IEmitter deathEvent)
        {
            this.hitPoints = hitPoints;
            this.deathEvent = deathEvent;
        }

        void IEnableListener.OnEnable()
        {
            this.hitPoints.OnValueChanged += this.OnHitPointsChanged;
            Debug.Log("ON ENABLE");
        }

        void IDisableListener.OnDisable()
        {
            this.hitPoints.OnValueChanged -= this.OnHitPointsChanged;
            Debug.Log("ON DISABLE");
        }

        private void OnHitPointsChanged(int hitPoints)
        {
            if (hitPoints <= 0)
            {
                this.deathEvent.Call();
            }
        }
    }
}