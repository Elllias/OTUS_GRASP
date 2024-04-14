using Entities;
using Game.GameEngine;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.Gameplay.Conveyors
{
    [RequireComponent(typeof(ConveyorModel))]
    public sealed class ConveyorEntity : MonoEntityBase
    {
        [SerializeField]
        private Transform unloadPoint;
    
        private void Awake()
        {
            this.CreateComponents();
            this.InitTriggers();
        }

        private void CreateComponents()
        {
            var model = this.GetComponent<ConveyorModel>();
            var core = model.core;
            var config = model.config;
            this.AddRange(
                new Component_Id(config.id),
                new Component_ObjectType(config.objectType),
                new Component_Enable(core.enableVariable),
                new Component_LoadZone(core.loadStorage, config.inputResourceType),
                new Component_UnloadZone(core.unloadStorage, config.outputResourceType, this.unloadPoint)
            );
        }

        private void InitTriggers()
        {
            foreach (var trigger in this.GetComponentsInChildren<ConveyorTrigger>())
            {
                trigger.Setup(this);
            }
        }
    }
}