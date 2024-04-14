using GameSystem;
using Sirenix.OdinInspector;

namespace Game.Meta
{
    public sealed class DialogueModule : GameModule
    {
        [GameService]
        [ShowInInspector]
        private DialoguePopupShower shower = new();
    }
}