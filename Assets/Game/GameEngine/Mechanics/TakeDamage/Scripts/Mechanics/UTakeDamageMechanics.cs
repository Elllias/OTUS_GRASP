using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public abstract class UTakeDamageMechanics : MonoBehaviour
    {
        [SerializeField]
        public UTakeDamageEngine takeDamageEngine;
        
        private void OnEnable()
        {
            this.takeDamageEngine.OnDamageTaken += this.OnDamageTaken;
        }

        private void OnDisable()
        {
            this.takeDamageEngine.OnDamageTaken -= this.OnDamageTaken;
        }

        protected abstract void OnDamageTaken(TakeDamageArgs damageArgs);
    }
}