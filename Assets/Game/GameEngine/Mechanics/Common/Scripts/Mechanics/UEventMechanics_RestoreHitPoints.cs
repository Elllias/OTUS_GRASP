using Elementary;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Event Mechanics «Restore Hit Points»")]
    public sealed class UEventMechanics_RestoreHitPoints : MonoEventMechanics
    {
        [SerializeField]
        public UHitPoints hitPointsEngine;

        protected override void OnEvent()
        {
            this.hitPointsEngine.RestoreToFull();
        }
    }
}