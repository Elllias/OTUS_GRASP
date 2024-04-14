using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class ShowPopupBehaviour : MonoBehaviour, IGameConstructElement
    {
        [SerializeField]
        private PopupName popupName;

        private PopupManager popupManager;

        [Button]
        public void ShowPopup()
        {
            this.popupManager.ShowPopup(this.popupName);
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.popupManager = context.GetService<PopupManager>();
        }
    }
}