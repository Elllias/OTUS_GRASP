using Elementary;
using Game.GameEngine.Animation;
using Game.GameEngine.GameResources;
using Game.GameEngine.Mechanics;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    public sealed class UHeroAnimatorMachine : UAnimatorMachine
    {
        [Space]
        [SerializeField]
        private ScriptableInt idleStateId;

        [SerializeField]
        private ScriptableInt moveStateId;

        [SerializeField]
        private ScriptableInt chopStateId;

        [SerializeField]
        private ScriptableInt attackStateId;

        [SerializeField]
        private ScriptableInt mineStateId;

        [SerializeField]
        private ScriptableInt dieStateId;

        [Title("References")]
        [SerializeField]
        private UHeroStateMachine stateMachine;

        [SerializeField]
        private UHarvestResourceOperator harvestEngine;

        protected override void OnEnable()
        {
            base.OnEnable();
            this.stateMachine.OnStateSwitched += this.OnStateChanged;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            this.stateMachine.OnStateSwitched -= this.OnStateChanged;
        }

        private void OnStateChanged(HeroStateId state)
        {
            if (state == HeroStateId.IDLE)
            {
                this.ChangeState(this.idleStateId.Current);
            }
            else if (state == HeroStateId.MOVE)
            {
                this.ChangeState(this.moveStateId.Current);
            }
            else if (state == HeroStateId.HARVEST_RESOURCE)
            {
                this.ChangeState(this.SelectHarvestAnimation());
            }
            else if (state == HeroStateId.MELEE_COMBAT)
            {
                this.ChangeState(this.attackStateId.Current);
            }
            else if (state == HeroStateId.DEATH)
            {
                this.ChangeState(this.dieStateId.Current);
            }
        }

        private int SelectHarvestAnimation()
        {
            var operation = this.harvestEngine.Current;
            var resourceType = operation.resourceType;
            if (resourceType == ResourceType.WOOD)
            {
                return this.chopStateId.Current;
            }

            if (resourceType == ResourceType.STONE)
            {
                return this.mineStateId.Current;
            }

            //By default:
            return this.chopStateId.Current;
        }
    }
}