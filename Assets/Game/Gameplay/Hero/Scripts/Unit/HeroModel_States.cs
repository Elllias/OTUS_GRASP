using System;
using System.Collections.Generic;
using Elementary;
using Game.GameEngine.Mechanics;
using Declarative;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public sealed class HeroModel_States
    {
        [ShowInInspector, ReadOnly]
        public StateMachineAuto<HeroStateId> stateMachine = new();

        [Section]
        private IdleState idleState = new();

        [Section]
        private MoveState moveState = new();

        [Section]
        private CombatState combatState = new();

        [Section]
        private HarvestState harvestState = new();

        [Section]
        private DeathState deathState = new();

        private readonly BoolMechanics boolMechanics = new();

        private readonly FixedUpdateMechanics updateMechanics = new();

        [Construct]
        private void ConstructStateMachine(HeroModel_Core core)
        {
            this.stateMachine.states = new List<StateEntry<HeroStateId>>
            {
                new(HeroStateId.IDLE, this.idleState),
                new(HeroStateId.MOVE, this.moveState),
                new(HeroStateId.MELEE_COMBAT, this.combatState),
                new(HeroStateId.HARVEST_RESOURCE, this.harvestState),
                new(HeroStateId.DEATH, this.deathState)
            };

            this.stateMachine.orderedTransitions = new List<StateTransition<HeroStateId>>
            {
                new(HeroStateId.DEATH, () => core.life.hitPoints.IsOver()),
                new(HeroStateId.MOVE, () => core.move.moveMotor.IsMoving),
                new(HeroStateId.MELEE_COMBAT, () => core.combat.combatOperator.IsActive),
                new(HeroStateId.HARVEST_RESOURCE, () => core.harvest.harvestOperator.IsActive),
                new(HeroStateId.IDLE, () => true)
            };
        }

        [Construct]
        private void ConstructMechanics(HeroModel_Core core)
        {
            var enableVariable = core.main.isEnable;
            this.boolMechanics.Construct(enableVariable, isEnable =>
            {
                if (isEnable)
                    this.stateMachine.Enter();
                else
                    this.stateMachine.Exit();
            });

            this.updateMechanics.Construct(_ =>
            {
                if (enableVariable.Current)
                {
                    this.stateMachine.Update();
                }
            });
        }

        private sealed class IdleState : StateComposite
        {
        }

        private sealed class MoveState : StateComposite
        {
            private readonly MoveInDirectionState_SurfacePosition positionState = new();

            private readonly MoveInDirectionState_Rotation rotationState = new();

            [Construct]
            private void ConstructSelf()
            {
                this.states = new List<IState>
                {
                    this.positionState,
                    this.rotationState
                };
            }

            [Construct]
            private void ConstructStates(HeroModel_Core core)
            {
                this.positionState.ConstructMotor(core.move.moveMotor);
                this.positionState.ConstructTransform(core.main.transformEngine);
                this.positionState.ConstructSurface(core.main.walkableSurface);
                this.positionState.ConstructSpeed(core.move.fullSpeed);

                this.rotationState.mode = MoveInDirectionState_Rotation.Mode.SMOOTH;
                this.rotationState.rotationSpeed = 45.0f;
                this.rotationState.ConstructMotor(core.move.moveMotor);
                this.rotationState.ConstructTransform(core.main.transformEngine);
            }
        }

        private sealed class HarvestState : StateComposite
        {
            private readonly HarvestResourceState_TimeProgress progressState = new();

            [Construct]
            private void ConstructSelf()
            {
                this.states = new List<IState>
                {
                    this.progressState,
                };
            }

            [Construct]
            private void ConstructProgressState(ScriptableHero config, HeroModel_Core core)
            {
                this.progressState.ConstructOperator(core.harvest.harvestOperator);
                this.progressState.ConstructDuration(new Value<float>(config.harvestDuration));
            }
        }

        private sealed class CombatState : StateComposite
        {
            private readonly CombatState_ControlTargetDistance distanceState = new();

            private readonly CombatState_ControlTargetDestroy destroyState = new();
            
            private readonly CombatState_UpdateRotation updateRotationState = new();

            [Construct]
            private void ConstructSelf()
            {
                this.states = new List<IState>
                {
                    this.distanceState,
                    this.destroyState,
                    this.updateRotationState
                };
            }

            [Construct]
            private void ConstructStates(ScriptableHero config, GameObject attacker, HeroModel_Core core)
            {
                var combatOperator = core.combat.combatOperator;
                var transform = core.main.transformEngine;
                
                this.distanceState.ConstructOperator(combatOperator);
                this.distanceState.ConstructTransform(transform);
                this.distanceState.ConstructMinDistance(config.combatDistance);

                this.destroyState.ConstructOperator(combatOperator);
                this.destroyState.ConstructAttacker(attacker);
                
                //Control rotation:
                this.updateRotationState.ConstructOperator(combatOperator);
                this.updateRotationState.ConstructTransform(transform);
                this.updateRotationState.mode = CombatState_UpdateRotation.Mode.SMOOTH;
                this.updateRotationState.rotationSpeed = 45.0f;
            }
        }

        private sealed class DeathState : StateComposite
        {
        }
    }
}