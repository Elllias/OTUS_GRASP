namespace AI.Commands
{
    public interface IAICommand
    {
        bool IsPlaying { get; }

        void Execute(object args, IAICommandCallback callback);

        void Interrupt();
    }
}