using System;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Commands
{
    public class AICommandExecutor<T> : IAICommandExecutor<T>, IAICommandCallback
    {
        public event Action<T, object> OnStarted;

        public event Action<T, object> OnFinished;

        public event Action<T, object> OnInterrupted;

        public bool IsRunning
        {
            get { return this.currentCommand != null; }
        }

        private readonly Dictionary<T, IAICommand> commands = new();

        private IAICommand currentCommand;

        private T currentKey;

        private object currentArgs;

        public AICommandExecutor(Dictionary<T, IAICommand> commands)
        {
            this.commands = commands;
        }

        public AICommandExecutor()
        {
        }

        public void Execute(T key, object args = null)
        {
            if (this.IsRunning)
            {
                Debug.LogWarning($"Other command {this.currentCommand.GetType().Name} is already run!");
                return;
            }

            if (!this.commands.TryGetValue(key, out this.currentCommand))
            {
                Debug.LogWarning($"Command with {key} is not found!");
                return;
            }

            this.currentKey = key;
            this.currentArgs = args;

            this.OnStarted?.Invoke(key, args);
            this.currentCommand.Execute(args, callback: this);
        }

        public void Interrupt()
        {
            if (!this.IsRunning)
            {
                return;
            }

            this.currentCommand.Interrupt();
            this.currentCommand = null;
            this.OnInterrupted?.Invoke(this.currentKey, this.currentArgs);
        }

        public bool TryGetRunningInfo(out T key, out object args)
        {
            key = this.currentKey;
            args = this.currentArgs;
            return this.currentCommand != null;
        }

        public void RegisterCommand(T key, IAICommand command)
        {
            this.commands.Add(key, command);
        }

        public void UnregisterCommand(T key)
        {
            this.commands.Remove(key);
        }

        void IAICommandCallback.Invoke(IAICommand command, object args, bool success)
        {
            this.currentCommand = null;
            this.OnFinished?.Invoke(this.currentKey, this.currentArgs);
        }
    }
}