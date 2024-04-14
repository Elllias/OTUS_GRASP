using Entities;

namespace Lessons.II.Gameplay.Lesson_CharacterInteraction.Scripts.Common
{
    public interface IOperation
    {
        T GetComponent<T>();
    }

    public interface IOperation2
    {
        T GetObject<T>(string key);
    }
}