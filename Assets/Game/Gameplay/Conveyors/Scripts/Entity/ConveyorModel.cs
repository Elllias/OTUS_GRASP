using System;
using Elementary;
using Game.GameEngine.GameResources;
using Declarative;
using UnityEngine;

namespace Game.Gameplay.Conveyors
{
    public sealed class ConveyorModel : DeclarativeModel
    {
        [Section]
        [SerializeField]
        public ScriptableConveyour config;

        [Section]
        [SerializeField]
        private ResourceInfoCatalog resourceCatalog;

        [Section]
        [SerializeField, Space]
        public Core core;

        [Section]
        [SerializeField]
        private Visual visual;

        [Section]
        [SerializeField]
        private Canvas canvas;

        [Serializable]
        public sealed class Core
        {
            [SerializeField]
            public BoolVariable enableVariable = new();

            [SerializeField, Space]
            public IntVariableLimited loadStorage = new();

            [SerializeField]
            public IntVariableLimited unloadStorage = new();

            [SerializeField, Space]
            public Timer workTimer = new();

            public WorkMechanics workMechanics = new();

            [Construct]
            private void ConstructStorages(ScriptableConveyour config)
            {
                this.loadStorage.MaxValue = config.inputCapacity;
                this.unloadStorage.MaxValue = config.outputCapacity;
            }

            [Construct]
            private void ConstructWork(ScriptableConveyour config)
            {
                this.workTimer.Duration = config.workTime;
                this.workMechanics.Construct(
                    isEnable: this.enableVariable,
                    loadStorage: this.loadStorage,
                    unloadStorage: this.unloadStorage,
                    workTimer: this.workTimer
                );
            }
        }
        
        [Serializable]
        public sealed class Visual
        {
            [SerializeField]
            private ConveyorVisual conveyorView;

            [SerializeField]
            private ZoneVisual loadZoneView;

            [SerializeField]
            private ZoneVisual unloadZoneView;

            private readonly ConveyorVisualAdapter conveyorViewAdapter = new();

            private readonly ZoneVisualAdapter loadZoneViewAdapter = new();

            private readonly ZoneVisualAdapter unloadZoneViewAdapter = new();

            [Construct]
            private void Construct(Core core)
            {
                this.conveyorViewAdapter.Construct(core.workTimer, this.conveyorView);
                this.loadZoneViewAdapter.Construct(core.loadStorage, this.loadZoneView);
                this.unloadZoneViewAdapter.Construct(core.unloadStorage, this.unloadZoneView);
            }
        }

        [Serializable]
        public sealed class Canvas
        {
            [SerializeField]
            private InfoWidget infoView;

            private readonly InfoWidgetAdapter infoViewAdapter = new();

            [Construct]
            private void Construct(ScriptableConveyour config, ResourceInfoCatalog resourceCatalog, Core core)
            {
                this.infoViewAdapter.Construct(core.workTimer, this.infoView);

                var inputType = config.inputResourceType;
                var inputIcon = resourceCatalog.FindResource(inputType).icon;
                this.infoView.SetInputIcon(inputIcon);

                var outputType = config.outputResourceType;
                var outputIcon = resourceCatalog.FindResource(outputType).icon;
                this.infoView.SetOutputIcon(outputIcon);
            }
        }
    }
}