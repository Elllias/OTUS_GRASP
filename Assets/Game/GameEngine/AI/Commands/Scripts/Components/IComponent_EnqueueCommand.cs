namespace Game.GameEngine.AI
{
    public interface IComponent_EnqueueCommand
    {
        bool IsRunning { get; }
        
        void Enqueue<T>(T args);
        
        void Interrupt();
    }
}