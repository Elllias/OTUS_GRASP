using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Harvest Resource/Harvest Resource State «Control Resource Distance»")]
    public sealed class UHarvestResourceState_ControlResourceDistance : UState_CheckDistanceToTarget
    {
        [Space]
        [SerializeField]
        public UHarvestResourceOperator engine;

        public IComponent_GetPosition targetComponent;

        public override void Enter()
        {
            this.targetComponent = engine
                .Current
                .targetResource
                .Get<IComponent_GetPosition>();
            
            base.Enter();
        }

        protected override void OnUpdate(bool distanceReached)
        {
            if (!distanceReached)
            {
                this.engine.Stop();
            }
        }

        protected override Vector3 GetTargetPosition()
        {
            return this.targetComponent.Position;
        }
    }
}