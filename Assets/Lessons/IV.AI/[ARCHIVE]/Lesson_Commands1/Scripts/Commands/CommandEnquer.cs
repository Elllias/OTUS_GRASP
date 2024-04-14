using System.Collections.Generic;
using Lessons.AI.Lesson_TaskManager;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.AI.Lesson_Commands1
{
    public sealed class CommandEnquer : MonoBehaviour
    {
        public bool IsPlaying
        {
            get { return this.commandQueue.Count > 0 || this.executor is {IsPlaying: true}; }
        }

        [SerializeField]
        private CommandExecutor executor;

        [ShowInInspector, ReadOnly]
        private readonly Queue<ICommandArgs> commandQueue = new();

        [Button]
        public void EnqueueCommand(ICommandArgs args)
        {
            this.commandQueue.Enqueue(args);
        }

        [Button]
        public void Interrupt()
        {
            this.executor.Interrupt();
            this.commandQueue.Clear();
        }

        private void Update()
        {
            if (!this.executor.IsPlaying && this.commandQueue.TryDequeue(out var args))
            {
                this.executor.Execute(args);
            }
        }
    }
}