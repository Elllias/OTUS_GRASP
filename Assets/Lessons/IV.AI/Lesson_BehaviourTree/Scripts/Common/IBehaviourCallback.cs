namespace Lessons.AI.LessonBehaviourTree
{
    public interface IBehaviourCallback
    {
        void Invoke(BehaviourNode node, bool success);
    }
}