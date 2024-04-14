using System;
using AI.Commands;
using UnityEngine;

namespace Game.GameEngine.AI
{
    public sealed class UComponent_ExecuteCommand : MonoBehaviour, IComponent_ExecuteCommand
    {
        public bool IsRunning
        {
            get { return this.executor; }
        }

        [SerializeField]
        private UnityAICommandExecutor<Type> executor;
        
        public void Execute<T>(T args)
        {
            this.executor.Execute(args);
        }

        public void ExecuteForce<T>(T args)
        {
            this.executor.ExecuteForce(args);
        }

        public void Interrupt()
        {
            this.executor.Interrupt();
        }
    }
}