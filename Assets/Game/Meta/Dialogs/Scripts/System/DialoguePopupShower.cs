using Game.GameEngine;
using GameSystem;
using Sirenix.OdinInspector;

namespace Game.Meta
{
    public sealed class DialoguePopupShower : IDialogueShower
    {
        [GameInject]
        private PopupManager popupManager;

        [Button]
        public void ShowDialog(DialogueConfig config)
        {
            var dialogue = new Dialogue(config);
            var presenter = new DialoguePresentationModel(dialogue);
            this.popupManager.ShowPopup(PopupName.DIALOGUE, presenter);
        }
    }
}