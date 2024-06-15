using System;
using Core.Controllers;
using Core.Tasks;
using JetBrains.Annotations;
using Sirenix.Utilities.Editor;
using UnityEngine;
using VContainer.Unity;

namespace Core.Pipelines
{
    [UsedImplicitly]
    public class GamePipelineInstaller : IInitializable, IDisposable
    {
        private readonly EventBus _eventBus;
        private readonly GamePipeline _pipeline;
        private readonly RedHeroesController _redHeroesController;
        private readonly BlueHeroesController _blueHeroesController;

        public GamePipelineInstaller(
            EventBus eventBus,
            GamePipeline pipeline, 
            RedHeroesController redHeroesController, 
            BlueHeroesController blueHeroesController)
        {
            _eventBus = eventBus;
            _pipeline = pipeline;
            _redHeroesController = redHeroesController;
            _blueHeroesController = blueHeroesController;
        }

        void IInitializable.Initialize()
        {
            _pipeline.AddTask(new StartTask());
            _pipeline.AddTask(new TurnTask(_eventBus, _redHeroesController.GetNextHero, _blueHeroesController));
            _pipeline.AddTask(new TurnTask(_eventBus, _blueHeroesController.GetNextHero, _redHeroesController));
            _pipeline.AddTask(new FinishTask());

            _pipeline.Finished += OnFinished;
        }

        void IDisposable.Dispose()
        {
            _pipeline.ClearTasks();
        }
        
        private void OnFinished()
        {
            if (!_redHeroesController.HasAliveHero())
            { 
                Debug.Log("Game is finished!");
                return;
            }
            
            if (!_blueHeroesController.HasAliveHero())
            { 
                Debug.Log("Game is finished!");
                return;
            }
            
            _pipeline.Run();
        }
    }
}