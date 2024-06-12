using Core.Pipelines;
using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace Core
{
    public class MainPipelineRunner : MonoBehaviour
    {
        private MainPipeline _pipeline;
        
        [Inject]
        private void Construct(MainPipeline pipeline)
        {
            _pipeline = pipeline;
        }
        
        [Button]
        public void Run()
        {
            _pipeline.Run();
        }
    }
}