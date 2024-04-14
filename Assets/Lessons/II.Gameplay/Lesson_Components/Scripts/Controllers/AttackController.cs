using UnityEngine;

namespace Lessons.Architecture.Components
{
    public sealed class AttackController : MonoBehaviour
    {
        [SerializeField]
        private EnemyDetector detector;

        [SerializeField]
        private Entity attacker;

        private void OnEnable()
        {
            this.detector.OnEnemyDetected += this.OnEnemyDetected;
        }

        private void OnDisable()
        {
            this.detector.OnEnemyDetected -= this.OnEnemyDetected;
        }

        private void OnEnemyDetected(Entity enemy)
        {
            this.attacker.Get<IAttackComponent>().Attack(enemy);
        }
    }
}