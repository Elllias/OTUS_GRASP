using Declarative;
using Lessons.Character.Model;

namespace Lessons.Character
{
    public sealed class CharacterModel : DeclarativeModel
    {
        [Section]
        public CharacterCore core;

        [Section]
        public CharacterVisual visual;
    }
}