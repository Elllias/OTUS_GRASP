using System.Runtime.Serialization;
using Elementary;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    public sealed class UHeroStateMachine : MonoStateMachine<HeroStateId>
    {
        [Space]
        [OptionalField]
        [SerializeField]
        private UMoveInDirectionMotor moveEngine;

        [OptionalField]
        [SerializeField]
        private UCombatOperator combatOperator;

        [OptionalField]
        [SerializeField]
        private UHarvestResourceOperator harvestEngine;

        [OptionalField]
        [SerializeField]
        private DestroyEventReceiver destroyReceiver;

        [OptionalField]
        [SerializeField]
        private MonoEmitter respawnReceiver;

        public override void Enter()
        {
            if (this.moveEngine != null)
            {
                this.moveEngine.OnStartMove += this.OnMoveStarted;
                this.moveEngine.OnStopMove += this.OnMoveEnded;
            }

            if (this.combatOperator != null)
            {
                this.combatOperator.OnStarted += this.OnCombatStarted;
                this.combatOperator.OnStopped += this.OnCombatEnded;
            }

            if (this.harvestEngine != null)
            {
                this.harvestEngine.OnStarted += this.OnHarvestStarted;
                this.harvestEngine.OnStopped += this.OnHarvestEnded;
            }

            if (this.destroyReceiver != null)
            {
                this.destroyReceiver.OnDestroy += this.OnDied;
            }

            if (this.respawnReceiver != null)
            {
                this.respawnReceiver.OnEvent += this.OnRespawned;
            }

            base.Enter();
        }

        public override void Exit()
        {
            if (this.moveEngine != null)
            {
                this.moveEngine.OnStartMove -= this.OnMoveStarted;
                this.moveEngine.OnStopMove -= this.OnMoveEnded;
            }

            if (this.combatOperator != null)
            {
                this.combatOperator.OnStarted -= this.OnCombatStarted;
                this.combatOperator.OnStopped -= this.OnCombatEnded;
            }

            if (this.harvestEngine != null)
            {
                this.harvestEngine.OnStarted -= this.OnHarvestStarted;
                this.harvestEngine.OnStopped -= this.OnHarvestEnded;
            }

            if (this.destroyReceiver != null)
            {
                this.destroyReceiver.OnDestroy -= this.OnDied;
            }

            if (this.respawnReceiver != null)
            {
                this.respawnReceiver.OnEvent -= this.OnRespawned;
            }

            base.Exit();
        }

        #region MechanicsEvents

        private void OnDied(DestroyArgs destroyArgs)
        {
            this.SwitchState(HeroStateId.DEATH);
        }

        private void OnMoveStarted()
        {
            this.SwitchState(HeroStateId.MOVE);
        }

        private void OnMoveEnded()
        {
            if (this.CurrentState == HeroStateId.MOVE)
            {
                this.SwitchState(HeroStateId.IDLE);
            }
        }

        private void OnHarvestStarted(HarvestResourceOperation operation)
        {
            this.SwitchState(HeroStateId.HARVEST_RESOURCE);
        }

        private void OnHarvestEnded(HarvestResourceOperation operation)
        {
            if (this.CurrentState == HeroStateId.HARVEST_RESOURCE)
            {
                this.SwitchState(HeroStateId.IDLE);
            }
        }

        private void OnCombatStarted(CombatOperation operation)
        {
            this.SwitchState(HeroStateId.MELEE_COMBAT);
        }

        private void OnCombatEnded(CombatOperation operation)
        {
            if (this.CurrentState == HeroStateId.MELEE_COMBAT)
            {
                this.SwitchState(HeroStateId.IDLE);
            }
        }

        private void OnRespawned()
        {
            if (this.CurrentState == HeroStateId.DEATH)
            {
                this.SwitchState(HeroStateId.IDLE);
            }
        }

        #endregion
    }
}