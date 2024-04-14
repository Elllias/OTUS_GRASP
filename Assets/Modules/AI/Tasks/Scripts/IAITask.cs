namespace AI.Tasks
{
    public interface IAITask
    {
        public bool IsPlaying { get; }

        public void Do(IAITaskCallback callback);

        public void Cancel();
    }
}