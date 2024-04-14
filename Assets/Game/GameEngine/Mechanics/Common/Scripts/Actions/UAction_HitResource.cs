using Elementary;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Common/Action «Deal Hit Resource»")]
    public sealed class UAction_HitResource : MonoAction
    {
        [SerializeField]
        public UHarvestResourceOperator engine;

        [Title("Methods")]
        [Button]
        [GUIColor(0, 1, 0)]
        public override void Do()
        {
            if (!this.engine.IsActive)
            {
                return;
            }

            this.engine.Current
                .targetResource
                .Get<IComponent_Hit>()
                .Hit();
        }
    }
}