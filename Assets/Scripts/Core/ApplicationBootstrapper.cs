using Core.Pipelines;
using JetBrains.Annotations;
using UnityEngine;
using VContainer.Unity;

namespace Core
{
    [UsedImplicitly]
    public class ApplicationBootstrapper : IStartable
    {
        private readonly MainPipeline _pipeline;

        public ApplicationBootstrapper(MainPipeline pipeline)
        {
            _pipeline = pipeline;
        }
        
        public void Start()
        {
            _pipeline.Run();
        }
    }
}