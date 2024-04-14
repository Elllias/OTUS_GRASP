using System.Collections.Generic;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class PopupModule : GameModule
    {
        [SerializeField]
        private PopupCatalog catalog;

        [SerializeField]
        private Transform container;
        
        [ShowInInspector]
        private readonly PopupManager manager = new();

        private readonly PopupSupplier supplier = new();

        private readonly PopupFactory factory = new();

        private readonly PopupInputController inputController = new();

        public override IEnumerable<IGameElement> GetElements()
        {
            yield return this.inputController;
        }

        public override IEnumerable<object> GetServices()
        {
            yield return this.manager;
        }

        public override void ConstructGame(GameContext context)
        {
            this.factory.Construct(this.catalog, this.container);
            this.supplier.Construct(context, this.factory);
            this.manager.SetSupplier(this.supplier);
            
            this.inputController.Construct(this.manager, context.GetService<InputStateManager>());
        }
    }
}