using System.Threading.Tasks;
using Game.App;
using Game.GameEngine.GUI;
using GameSystem;
using Services;
using UnityEngine;

namespace Game.Tutorial.App
{
    public sealed class TutorialDeployer : IAppInitListener
    {
        private const string ENGINE_NAME = "Tutorial";

        private TutorialAssetSupplier assetSupplier;

        private GameFacade gameFacade;

        void IAppInitListener.Init()
        {
            this.assetSupplier = ServiceLocator.GetService<TutorialAssetSupplier>();
            this.gameFacade = ServiceLocator.GetService<GameFacade>();
        }

        public async Task DeployTutorial()
        {
            var manager = TutorialManager.Instance;
            if (manager.IsCompleted)
            {
                return;
            }

            //Load tutorial engine:
            var enginePrefab = await this.assetSupplier.LoadTutorialEngine();
            var engine = GameObject.Instantiate(enginePrefab);
            engine.name = ENGINE_NAME;
            
            //Load tutorial gui:
            var guiPrefab = await this.assetSupplier.LoadTutorialInterface();
            var canvasService = this.gameFacade.GetService<GUICanvasService>();
            var gui = GameObject.Instantiate(guiPrefab, canvasService.RootTransform);
            gui.name = guiPrefab.name;
            
            //Register services:
            this.gameFacade.RegisterService(engine.GetComponent<IGameServiceGroup>());
            this.gameFacade.RegisterService(gui.GetComponent<IGameServiceGroup>());

            //Register elements:
            this.gameFacade.RegisterElement(engine.GetComponent<IGameElementGroup>());
            this.gameFacade.RegisterElement(gui.GetComponent<IGameElementGroup>());
        }
    }
}