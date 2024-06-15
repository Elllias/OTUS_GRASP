using Core.Pipelines;
using JetBrains.Annotations;
using UnityEngine;
using VContainer.Unity;

namespace Core
{
    [UsedImplicitly]
    public class ApplicationBootstrapper : IStartable
    {
        private readonly Pipeline _pipeline;

        public ApplicationBootstrapper(Pipeline pipeline)
        {
            _pipeline = pipeline;
        }
        
        public void Start()
        {
            _pipeline.Run();
        }
    }
}