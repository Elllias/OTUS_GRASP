using Entities;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public abstract class UTakeDamageObserver : MonoBehaviour
    {
        [SerializeField]
        public MonoEntity unit;
        
        private IComponent_OnDamageTaken takeDamageComponent;

        private void OnEnable()
        {
            this.takeDamageComponent = this.unit.Get<IComponent_OnDamageTaken>(); 
            this.takeDamageComponent.OnDamageTaken += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            this.takeDamageComponent.OnDamageTaken -= this.OnDamageTaken;
            this.takeDamageComponent = null;
        }

        protected abstract void OnDamageTaken(TakeDamageArgs obj);
    }
}