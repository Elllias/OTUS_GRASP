using Core.Pipelines;
using JetBrains.Annotations;
using UnityEngine;
using VContainer.Unity;

namespace Core
{
    [UsedImplicitly]
    public class ApplicationBootstrapper : IStartable
    {
        private readonly GamePipeline _pipeline;

        public ApplicationBootstrapper(GamePipeline pipeline)
        {
            _pipeline = pipeline;
        }
        
        public void Start()
        {
            /*_pipeline.Finished += _pipeline.Run;
            _pipeline.GameFinished += */
            _pipeline.Run();
        }
    }
}