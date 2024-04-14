using System;
using Elementary;
using Entities;
using Game.GameEngine;
using Game.GameEngine.Mechanics;
using Declarative;
using UnityEngine;

namespace Game.Gameplay.ResourceObjects
{
    public sealed class ResourceModel : DeclarativeModel
    {
        [Section]
        [SerializeField]
        private ScriptableResource config;

        [Section]
        [SerializeField, Space]
        private Core core;

        [Section]
        [SerializeField]
        private Components components;

        [Section]
        [SerializeReference]
        private IVisual visual;

        [Serializable]
        public sealed class Core
        {
            [SerializeField]
            public Transform rootTransform;

            [SerializeField]
            public GameObject collisionLayer;

            [Space]
            [SerializeField]
            public BoolVariable isActive = new();

            [SerializeField]
            public Emitter takeHitEvent = new();

            [SerializeField]
            public Emitter destroyEvent = new();
            
            [SerializeField]
            public Emitter respawnEvent = new();
            
            private readonly BoolMechanics activeMechanics = new();

            private readonly RespawnMechanics respawnMechanics = new();

            [Construct]
            private void ConstructActiveMechanics()
            {
                this.activeMechanics.Construct(this.isActive, this.collisionLayer.SetActive);
            }

            [Construct]
            private void ConstructDestroy()
            {
                this.destroyEvent.AddListener(() => this.isActive.Current = false);
            }

            [Construct]
            private void ConstructRespawn(MonoBehaviour context, ScriptableResource config)
            {
                this.respawnMechanics.ConstructDuration(config.respawnTime);
                this.respawnMechanics.ConstructDestroyEvent(this.destroyEvent);
                this.respawnMechanics.ConstructRespawnEvent(this.respawnEvent);

                this.respawnEvent.AddListener(() => this.isActive.Current = true);
            }
        }

        [Serializable]
        public sealed class Components
        {
            [SerializeField]
            private MonoEntityStd entity;

            [Construct]
            private void Construct(ScriptableResource config, Core core)
            {
                this.entity.AddRange(
                    new Component_Transform(core.rootTransform),
                    new Component_ObjectType(config.objectType),
                    new Component_ResourceInfo(config),
                    new Component_Hit(core.takeHitEvent),
                    new Component_CanDestoy_BoolVariable(core.isActive),
                    new Component_Destroy_Emitter(core.destroyEvent)
                );
            }
        }

        public interface IVisual
        {
        }

        [Serializable]
        public class BaseVisual : IVisual
        {
            [SerializeField]
            private GameObject visualObject;

            [Construct]
            private void Construct(Core core)
            {
                core.isActive.AddListener(this.visualObject.SetActive);
            }
        }

        [Serializable]
        public class TreeVisual : BaseVisual
        {
            [SerializeField]
            private Animator animator;

            [Construct]
            private void Construct(Core core)
            {
                core.takeHitEvent.AddListener(() => this.animator.Play("Chop", -1, 0));
            }
        }
    }
}