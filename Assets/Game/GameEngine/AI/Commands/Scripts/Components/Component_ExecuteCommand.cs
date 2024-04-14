using System;
using AI.Commands;

namespace Game.GameEngine.AI
{
    public sealed class Component_ExecuteCommand : IComponent_ExecuteCommand
    {
        public bool IsRunning
        {
            get { return this.executor.IsRunning; }
        }

        private readonly IAICommandExecutor<Type> executor;

        public Component_ExecuteCommand(IAICommandExecutor<Type> executor)
        {
            this.executor = executor;
        }

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