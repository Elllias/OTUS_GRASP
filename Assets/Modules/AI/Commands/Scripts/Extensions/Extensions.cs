using System;

namespace AI.Commands
{
    public static class Extensions
    {
        public static void Execute<T>(this IAICommandExecutor<Type> it, T args)
        {
            it.Execute(typeof(T), args);
        }

        public static void RegisterCommand<T>(this IAICommandExecutor<Type> it, IAICommand command)
        {
            it.RegisterCommand(typeof(T), command);
        }
        
        public static void UnregisterCommand<T>(this IAICommandExecutor<Type> it)
        {
            it.UnregisterCommand(typeof(T));
        }
        
        public static void ExecuteForce<T>(this IAICommandExecutor<Type> it, T args)
        {
            it.ExecuteForce(typeof(T), args);
        }

        public static void ExecuteForce<T>(this IAICommandExecutor<T> it, T key, object args = null)
        {
            it.Interrupt();
            it.Execute(key, args);
        }
        
        public static void Enqueue<T>(this IAICommandEnqueuer<Type> it, T args)
        {
            it.Enqueue(typeof(T), args);
        }
        
        public static void ExecuteForce<T>(this IAICommandEnqueuer<T> it, T key, object args = null)
        {
            it.Interrupt();
            it.Enqueue(key, args);
        }
    }
}