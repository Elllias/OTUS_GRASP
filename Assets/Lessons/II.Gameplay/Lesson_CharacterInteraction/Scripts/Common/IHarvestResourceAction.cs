using Lessons.Gameplay.CharacterInteraction;

namespace Lessons.Gameplay.Lesson_CharacterInteraction
{
    public interface IHarvestResourceAction
    {
        void Do(HarvestResourceOperation operation);
    }
}