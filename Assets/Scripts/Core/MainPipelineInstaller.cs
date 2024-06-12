using System;
using Core.Pipelines;
using Core.Tasks;
using JetBrains.Annotations;
using VContainer.Unity;

namespace Core
{
    [UsedImplicitly]
    public class MainPipelineInstaller : IInitializable, IDisposable
    {
        private readonly MainPipeline _pipeline;
        
        public MainPipelineInstaller(MainPipeline pipeline)
        {
            _pipeline = pipeline;
        }

        void IInitializable.Initialize()
        {
            _pipeline.AddTask(new StartTask());
            _pipeline.AddTask(new RedTurnTask());
            _pipeline.AddTask(new BlueTurnTask());
            _pipeline.AddTask(new FinishTask());
        }

        void IDisposable.Dispose()
        {
            _pipeline.ClearTasks();
        }
    }
}