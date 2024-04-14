using Lessons.AI.Lesson_TaskManager;
using UnityEngine;

namespace Lessons.AI.Lesson_Commands1
{
    public interface IStopComponent
    {
        void Stop();
    }
    
    public sealed class StopComponent : MonoBehaviour, IStopComponent
    {
        [SerializeField]
        private CommandExecutor executor;
        
        public void Stop()
        {
            this.executor.Interrupt();
        }
    }
}