using System;
using Entities;
using Game.GameEngine;
using Game.GameEngine.Mechanics;
using Declarative;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public sealed class HeroModel_Components
    {
        [SerializeField]
        private MonoEntityStd entity;

        [SerializeField]
        private Transform movingPivot;

        [Construct]
        private void Construct(HeroModel_Core core, HeroModel_Collision collision, ScriptableHero config)
        {
            this.entity.AddRange(
                new Component_TransformEngine(core.main.transformEngine),
                new Component_Enable(core.main.isEnable),
                new Component_SetWalkableSurface(core.main.walkableSurface),
                new Component_MoveInDirection(core.move.moveMotor),
                new Component_MoveSpeed(core.move.baseSpeed),
                new Component_ColliderSensor(collision.collisionSensor),
                new Component_TriggerSensor(collision.triggerSensor),
                new Component_ObjectType(ObjectType.HERO),
                new Component_HarvestResource(core.harvest.harvestOperator),
                new Component_MeleeCombat(core.combat.combatOperator),
                new Component_MeleeDamage(core.combat.baseDamage),
                new Component_HitPoints(core.life.hitPoints),
                new Component_TakeDamage(core.life.takeDamageEngine),
                new Component_Destroy_Emitter<DestroyArgs>(core.life.deathEmitter),
                new Component_IsAlive_HitPoints(core.life.hitPoints),
                new Component_IsDestroyed_HitPoints(core.life.hitPoints),
                new Component_Respawn(core.life.respawnEmitter),
                new Component_Effector(core.effects.effector),
                new Component_GetPivot(this.movingPivot)
            );
        }
    }
}