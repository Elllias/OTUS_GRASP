using System;
using Elementary;
using Entities;
using Game.GameEngine;
using Game.GameEngine.GameResources;
using JetBrains.Annotations;
using Declarative;
using UnityEngine;

namespace Game.Gameplay.Vendors
{
    public sealed class VendorModel : DeclarativeModel
    {
        [Section]
        [SerializeField]
        private ScriptableVendor config;

        [Section]
        [SerializeField]
        private ResourceInfoCatalog resourceCatalog;

        [Section]
        [SerializeField, Space]
        private Core core;

        [Section]
        [SerializeField]
        private Components components;

        [Section]
        [SerializeField]
        private Visual visual;

        [Section]
        [SerializeField]
        private Canvas canvas;
        
        [Serializable]
        private sealed class Core
        {
            public Emitter dealEmitter = new();
        }

        [Serializable]
        private sealed class Components
        {
            [SerializeField]
            private MonoEntityStd entity;

            [SerializeField]
            private Transform particlePoint;

            [Construct]
            private void Construct(ScriptableVendor config, Core core)
            {
                this.entity.Add(new Component_Info(config));
                this.entity.Add(new Component_ObjectType(config.objectType));
                this.entity.Add(new Component_CompleteDeal(core.dealEmitter));
                this.entity.Add(new Component_GetParticlePosition(this.particlePoint));
            }
        }

        [Serializable]
        private sealed class Visual
        {
            [SerializeField]
            private Animator animator;
            
            [SerializeField]
            private string dealAnimation = "Dance";

            [Construct]
            private void Construct(Core core)
            {
                core.dealEmitter.AddListener(() => this.animator.Play(this.dealAnimation, -1, 0));
            }
        }

        [Serializable]
        private sealed class Canvas
        {
            [SerializeField]
            private InfoWidget infoView;

            [SerializeField]
            private RectTransform moveTransform;

            private readonly UIParryMechanics parryMechanics = new();

            [Construct]
            private void ConstructView(ScriptableVendor config, ResourceInfoCatalog resourceCatalog)
            {
                var resourceType = config.resourceType;
                var pricePerResource = config.pricePerOne;
                var resourceIcon = resourceCatalog.FindResource(resourceType).icon;
                this.infoView.SetPrice(pricePerResource.ToString());
                this.infoView.SetIcon(resourceIcon);
            }

            [Construct]
            private void ConstructParry()
            {
                this.parryMechanics.moveTransform = this.moveTransform;
            }
        }
    }
}