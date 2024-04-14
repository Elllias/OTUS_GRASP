using System;
using System.Collections.Generic;
using Elementary;
using Game.GameEngine.Animation;
using Game.GameEngine.GameResources;
using Game.GameEngine.Mechanics;
using Declarative;
using Sirenix.OdinInspector;
using UnityEngine;
using static Game.Gameplay.Hero.HeroStateId;
using StateDelegate = Elementary.StateDelegate;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public sealed class HeroModel_Animations
    {
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private AnimatorObservable animatorObservable;

        [ShowInInspector, ReadOnly]
        private readonly AnimatorMachine animatorMachine = new();

        [Section]
        [SerializeField]
        private Common common;

        [Section]
        [SerializeField]
        private IdleState idleState = new();

        [Section]
        [SerializeField]
        private MoveState moveState = new();

        [Section]
        [SerializeField]
        private ChopState chopState = new();

        [Section]
        [SerializeField]
        private MineState mineState = new();

        [Section]
        [SerializeField]
        private CombatState combatState = new();

        [Section]
        [SerializeField]
        private DeathState deathState = new();

        [Construct]
        private void Construct(HeroModel_States states, HeroModel_Core core)
        {
            this.animatorMachine.Construct(this.animator, this.animatorObservable);

            const int IDLE_ANIM = 0;
            const int MOVE_ANIM = 1;
            const int CHOP_ANIM = 2;
            const int COMBAT_ANIM = 3;
            const int MINE_ANIM = 4;
            const int DEATH_ANIM = 5;

            this.animatorMachine.states = new List<AnimatorMachine.StateEntry>
            {
                new(IDLE_ANIM, this.idleState),
                new(MOVE_ANIM, this.moveState),
                new(CHOP_ANIM, this.chopState),
                new(MINE_ANIM, this.mineState),
                new(COMBAT_ANIM, this.combatState),
                new(DEATH_ANIM, this.deathState),
            };

            var fsm = states.stateMachine;
            var harvester = core.harvest.harvestOperator;

            this.animatorMachine.orderedTransitions = new List<AnimatorMachine.StateTransition>
            {
                new(IDLE_ANIM, () => fsm.CurrentState == IDLE),
                new(MOVE_ANIM, () => fsm.CurrentState == MOVE),
                new(CHOP_ANIM, () => fsm.CurrentState == HARVEST_RESOURCE && IsResource(ResourceType.WOOD)),
                new(MINE_ANIM, () => fsm.CurrentState == HARVEST_RESOURCE && IsResource(ResourceType.STONE)),
                new(COMBAT_ANIM, () => fsm.CurrentState == MELEE_COMBAT),
                new(DEATH_ANIM, () => fsm.CurrentState == DEATH)
            };

            bool IsResource(ResourceType resourceType)
            {
                if (!harvester.IsActive)
                {
                    return false;
                }
                
                return harvester.Current.resourceType == resourceType;
            }
        }

        [Serializable]
        private sealed class Common
        {
            [Space]
            [SerializeField]
            public GameObject axe;

            [SerializeField]
            public GameObject pickAxe;

            [SerializeField]
            public GameObject sword;

            [Space]
            [SerializeField]
            public ParticleSystem chopVFX;

            [SerializeField]
            public ParticleSystem mineVFX;

            public readonly AnimatorState_ResetRootMotion resetRootMotionState = new();

            public readonly AnimatorState_ApplyRootMotion applyRootMotionState = new();

            [Construct]
            private void ConstructRootMotion(HeroModel_Animations animations)
            {
                this.resetRootMotionState.ConstructMachine(animations.animatorMachine);
                this.applyRootMotionState.ConstructMachine(animations.animatorMachine);
            }
        }

        private sealed class IdleState : StateComposite
        {
            [Construct]
            private void ConstructSelf(Common common)
            {
                this.states = new List<IState>
                {
                    common.resetRootMotionState,
                };
            }
        }

        [Serializable]
        private sealed class MoveState : StateComposite
        {
            private readonly AnimatorState_ListenEvent stepListener = new();

            [SerializeField]
            private string stepSoundId = "Step";

            [Construct]
            private void ConstructSelf(Common common)
            {
                this.states = new List<IState>
                {
                    common.resetRootMotionState,
                    this.stepListener
                };
            }

            [Construct]
            private void ConstructStepListener(HeroModel_Animations animations, HeroModel_Audio audio)
            {
                this.stepListener.ConstructAnimEvents("step");
                this.stepListener.ConstructAnimMachine(animations.animatorMachine);
                this.stepListener.ConstructAction(() => audio.soundEmitter.PlaySound(this.stepSoundId));
            }
        }

        [Serializable]
        private sealed class ChopState : StateComposite
        {
            private readonly AnimatorState_ListenEvent chopListener = new();

            private readonly StateDelegate stateObserver = new();

            [SerializeField]
            private string chopSoundId = "Chop";

            [Construct]
            private void ConstructSelf(Common common)
            {
                this.states = new List<IState>
                {
                    common.resetRootMotionState,
                    this.chopListener,
                    this.stateObserver
                };
            }

            [Construct]
            private void ConstructChopListener(
                HeroModel_Core core,
                HeroModel_Animations animations,
                HeroModel_Audio audio
            )
            {
                this.chopListener.ConstructAnimEvents("chop");
                this.chopListener.ConstructAnimMachine(animations.animatorMachine);
                this.chopListener.ConstructAction(() =>
                {
                    core.harvest.harvestOperator.Current?.targetResource.Get<IComponent_Hit>().Hit();
                    audio.soundEmitter.PlaySound(this.chopSoundId);
                    animations.common.chopVFX.Play(withChildren: true);
                });
            }

            [Construct]
            private void ConstructStateObserver(Common common)
            {
                var axe = common.axe;
                axe.SetActive(false);
                this.stateObserver.Construct(axe.SetActive);
            }
        }

        [Serializable]
        private sealed class MineState : StateComposite
        {
            private readonly AnimatorState_ListenEvent mineListener = new();

            private readonly StateDelegate stateObserver = new();

            [SerializeField]
            private string mineSoundId = "Mine";

            [Construct]
            private void ConstructSelf(Common common)
            {
                this.states = new List<IState>
                {
                    common.resetRootMotionState,
                    this.mineListener,
                    this.stateObserver
                };
            }

            [Construct]
            private void ConstructMineListener(Common common, HeroModel_Animations animations, HeroModel_Audio audio)
            {
                this.mineListener.ConstructAnimEvents("mine");
                this.mineListener.ConstructAnimMachine(animations.animatorMachine);
                this.mineListener.ConstructAction(() =>
                {
                    audio.soundEmitter.PlaySound(this.mineSoundId);
                    common.mineVFX.Play(withChildren: true);
                });
            }

            [Construct]
            private void ConstructStateObserver(Common common)
            {
                var pickAxe = common.pickAxe;
                pickAxe.SetActive(false);
                this.stateObserver.Construct(pickAxe.SetActive);
            }
        }

        [Serializable]
        private sealed class CombatState : StateComposite
        {
            private readonly StateDelegate stateObserver = new();

            private readonly AnimatorState_ListenEvent dealDamageListener = new();

            [SerializeField]
            private string hitSoundId = "Hit";

            [Construct]
            private void ConstructSelf(Common common)
            {
                this.states = new List<IState>
                {
                    common.resetRootMotionState,
                    this.dealDamageListener,
                    this.stateObserver
                };
            }

            [Construct]
            private void ConstructDealDamageListener(
                HeroModel_Animations animations,
                HeroModel_Core core,
                HeroModel_Audio audio)
            {
                this.dealDamageListener.ConstructAnimEvents("attack");
                this.dealDamageListener.ConstructAnimMachine(animations.animatorMachine);
                this.dealDamageListener.ConstructAction(() =>
                {
                    core.combat.DealDamage();
                    audio.soundEmitter.PlaySound(this.hitSoundId);
                });
            }

            [Construct]
            private void ConstructStateObserver(Common common)
            {
                var sword = common.sword;
                sword.SetActive(false);
                this.stateObserver.Construct(sword.SetActive);
            }
        }

        private sealed class DeathState : StateComposite
        {
            [Construct]
            private void ConstructSelf(Common common)
            {
                this.states = new List<IState>
                {
                    common.applyRootMotionState,
                };
            }
        }
    }
}