using System.Collections;
using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public abstract class UState_RotateTowardsTarget : MonoStateCoroutine
    {
        [SerializeField]
        private FloatAdapter rotationSpeed;

        [SerializeField]
        private UTransformEngine engine;

        protected override IEnumerator Do()
        {
            while (true)
            {
                this.engine.RotateTowardsAtPosition(
                    targetPosition: this.GetTargetPosition(),
                    speed: this.rotationSpeed.Current,
                    deltaTime: Time.deltaTime
                );
                yield return null;
            }
        }

        protected abstract Vector3 GetTargetPosition();
    }
}