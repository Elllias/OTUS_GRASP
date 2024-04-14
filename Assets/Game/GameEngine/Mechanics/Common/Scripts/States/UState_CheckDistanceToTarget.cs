using System.Collections;
using Elementary;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.GameEngine.Mechanics
{
    public abstract class UState_CheckDistanceToTarget : MonoStateCoroutine
    {
        [Space]
        [SerializeField]
        [FormerlySerializedAs("engine")]
        private UTransformEngine transformEngine;

        [SerializeField]
        private FloatAdapter minDistance; // 1.2f;

        protected override IEnumerator Do()
        {
            var period = new WaitForFixedUpdate();
            while (true)
            {
                var targetPosiiton = this.GetTargetPosition();
                var distanceReached = this.transformEngine.IsDistanceReached(targetPosiiton, this.minDistance.Current);
                this.OnUpdate(distanceReached);
                yield return period;
            }
        }

        protected abstract void OnUpdate(bool distanceReached);
        
        protected abstract Vector3 GetTargetPosition();
    }
}