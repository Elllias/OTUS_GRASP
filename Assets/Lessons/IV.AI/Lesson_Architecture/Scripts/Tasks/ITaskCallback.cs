namespace Lessons.AI.Architecture
{
    public interface ITaskCallback
    {
        void OnComplete(Task task, bool success);
    }
}