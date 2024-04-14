namespace AI.Tasks
{
    public interface IAITaskCallback
    {
        void Invoke(IAITask task, bool success);
    }
}