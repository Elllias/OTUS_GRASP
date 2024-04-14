using System;
using Elementary;
using Game.GameEngine;
using Game.GameEngine.Mechanics;
using Declarative;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public sealed class HeroModel_Core
    {
        [Section]
        public Main main;

        [Section]
        public Move move;

        [Section]
        public Harvest harvest;

        [Section]
        public Combat combat;

        [Section]
        public Life life;

        [Section]
        public Effects effects;

        [Serializable]
        public sealed class Main
        {
            public TransformEngine transformEngine = new();

            public BoolVariable isEnable = new();

            [NonSerialized]
            public Variable<IWalkableSurface> walkableSurface = new();
        }

        [Serializable]
        public sealed class Move
        {
            [ShowInInspector, ReadOnly]
            public MoveInDirectionMotor moveMotor;

            [Space]
            public FloatVariable baseSpeed;

            public FloatVariable multiplier;

            public FloatVariable fullSpeed;

            private readonly FixedUpdateMechanics updateMechanics = new();

            private readonly MoveSpeedConnector speedConnector = new();

            [Construct]
            private void ConstructMotor(Life life, Harvest harvest, Combat combat)
            {
                this.moveMotor.AddPrecondition(_ => life.hitPoints.IsExists());
                this.moveMotor.AddStartAction(_ => harvest.harvestOperator.Stop());
                this.moveMotor.AddStartAction(_ => combat.combatOperator.Stop());
            }

            [Construct]
            private void ConstructMechanics(Main main)
            {
                this.updateMechanics.Construct(_ =>
                {
                    if (main.isEnable.Current) this.moveMotor.Update();
                });

                this.speedConnector.Construct(this.baseSpeed, this.multiplier, this.fullSpeed);
            }

            [Construct]
            private void ConstructSpeed(ScriptableHero config)
            {
                this.baseSpeed.Current = config.baseSpeed;
                this.multiplier.Current = config.baseSpeedMultiplier;
            }
        }

        [Serializable]
        public sealed class Harvest
        {
            [ShowInInspector, ReadOnly]
            public readonly Operator<HarvestResourceOperation> harvestOperator = new();

            [Construct]
            private void ConstructHarvest(ScriptableHero config, Main main, Move move, Life life, Combat combat)
            {
                var transform = main.transformEngine;

                var checkDistance = new HarvestResourceCondition_CheckDistance(transform, config.harvestDistance);
                var checkTarget = new HarvestResourceCondition_CheckEntity(config.harvestConditions);
                
                this.harvestOperator.AddCondition(checkDistance);
                this.harvestOperator.AddCondition(checkTarget);
                this.harvestOperator.AddCondition(_ => life.hitPoints.IsExists());
                this.harvestOperator.AddCondition(_ => !move.moveMotor.IsMoving);
                this.harvestOperator.AddCondition(_ => !combat.combatOperator.IsActive);

                this.harvestOperator.AddStartAction(_ => combat.combatOperator.Stop());
                this.harvestOperator.AddStartAction(new HarvestResourceAction_LookAtResource(transform));

                this.harvestOperator.AddStopAction(new HarvestResourceAction_DestroyResourceIfCompleted());
            }
        }

        [Serializable]
        public sealed class Combat
        {
            [ShowInInspector, ReadOnly]
            public readonly Operator<CombatOperation> combatOperator = new();

            public IntVariable baseDamage;

            public FloatVariable multiplier;

            public IntVariable fullDamage;

            private readonly DamageConnector damageConnector = new();

            private CombatAction_DealDamageIfAlive damageAction = new();

            [Construct]
            private void ConstructCombat(ScriptableHero config, Main main, Move move, Life life, Harvest harvest)
            {
                var transformEngine = main.transformEngine;

                var checkEntity = new CombatCondition_CheckEntity(config.combatConditions);
                var checkDistance = new CombatCondition_CheckDistance(transformEngine, config.combatDistance);

                this.combatOperator.AddCondition(_ => !move.moveMotor.IsMoving);
                this.combatOperator.AddCondition(_ => life.hitPoints.IsExists());
                this.combatOperator.AddCondition(checkEntity);
                this.combatOperator.AddCondition(checkDistance);

                this.combatOperator.AddStartAction(new CombatAction_LookAtTarget(transformEngine));
                this.combatOperator.AddStartAction(_ => harvest.harvestOperator.Stop());
            }

            [Construct]
            private void ConstructDamageStats(ScriptableHero config)
            {
                this.damageConnector.Construct(this.baseDamage, this.multiplier, this.fullDamage);
                this.baseDamage.Current = config.baseDamage;
                this.multiplier.Current = config.baseDamageMultiplier;
            }

            [Construct]
            private void ConstructDamageAction(GameObject attacker)
            {
                this.damageAction.attacker = attacker;
                this.damageAction.damage = this.fullDamage;
            }

            public void DealDamage()
            {
                if (this.combatOperator.IsActive)
                {
                    this.damageAction.Do(this.combatOperator.Current);
                }
            }
        }

        [Serializable]
        public sealed class Life
        {
            [SerializeField]
            public HitPoints hitPoints = new();

            [SerializeField]
            public TakeDamageEngine takeDamageEngine = new();

            [ShowInInspector]
            public readonly Emitter<DestroyArgs> deathEmitter = new();

            [ShowInInspector]
            public readonly Emitter respawnEmitter = new();

            private readonly RestoreHitPointsMechanics restoreMechanics = new();

            [Construct]
            private void ConstructHitPoints(ScriptableHero config)
            {
                var hitPoints = config.baseHitPoints;
                this.hitPoints.Setup(hitPoints, hitPoints);
            }

            [Construct]
            private void ConstructRestoreMechanics()
            {
                this.restoreMechanics.SetDelay(2.5f);
                this.restoreMechanics.SetPeriod(1.0f);
                this.restoreMechanics.SetRestoreAtTime(1);
                this.restoreMechanics.Construct(this.hitPoints, this.takeDamageEngine);
            }

            [Construct]
            private void ConstructDeath(Combat combat, Harvest harvest, Move move)
            {
                this.deathEmitter.AddListener(_ => this.hitPoints.Setup(0, this.hitPoints.Max));
                this.deathEmitter.AddListener(_ => combat.combatOperator.Stop());
                this.deathEmitter.AddListener(_ => harvest.harvestOperator.Stop());
                this.deathEmitter.AddListener(_ => move.moveMotor.Interrupt());
            }

            [Construct]
            private void ConstructTakeDamage()
            {
                this.takeDamageEngine.Construct(this.hitPoints, this.deathEmitter);
            }

            [Construct]
            private void ConstructRespawn()
            {
                this.respawnEmitter.AddListener(this.hitPoints.RestoreToFull);
            }
        }

        [Serializable]
        public sealed class Effects
        {
            [ShowInInspector]
            public Effector<IEffect> effector = new();

            [Construct]
            private void Construct(Combat combat, Move move)
            {
                this.effector.AddHandler(new EffectHandler_MeleeDamage(combat.multiplier));
                this.effector.AddHandler(new EffectHandler_MoveSpeed(move.multiplier));
            }
        }
    }
}