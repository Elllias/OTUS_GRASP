namespace AI.Commands
{
    public interface IAICommandCallback
    {
        void Invoke(IAICommand command, object args, bool success);
    }
}