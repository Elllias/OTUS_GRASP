namespace Game.GameEngine.AI
{
    public interface IComponent_ExecuteCommand
    {
        bool IsRunning { get; }
        
        void Execute<T>(T args);

        void ExecuteForce<T>(T args);

        void Interrupt();
    }
}