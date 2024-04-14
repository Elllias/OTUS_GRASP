using Lessons.Gameplay.CharacterInteraction;

namespace Lessons.Gameplay.Lesson_CharacterInteraction
{
    public interface IHarvestResourceCondition
    {
        bool IsTrue(HarvestResourceOperation operation);
    }
}