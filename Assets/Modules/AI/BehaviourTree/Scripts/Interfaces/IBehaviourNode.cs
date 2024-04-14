namespace AI.BTree
{
    public interface IBehaviourNode
    {
        bool IsRunning { get; }

        void Run(IBehaviourCallback callback = null);
        
        void Abort();
    }
}