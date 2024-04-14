using System;
using Game.GameEngine;
using UnityEngine;

namespace Game.Gameplay.Player
{
    [CreateAssetMenu(
        fileName = "WorldPlacePopupConfig",
        menuName = "Gameplay/Player/New WorldPlacePopupConfig"
    )]
    public sealed class WorldPlacePopupConfig : ScriptableObject
    {
        [SerializeField]
        private PopupInfo[] popups;
        
        public bool FindPopupName(WorldPlaceType placeType, out PopupName popupName)
        {
            for (int i = 0, count = this.popups.Length; i < count; i++)
            {
                var popupInfo = this.popups[i];
                if (popupInfo.placeType == placeType)
                {
                    popupName = popupInfo.popupName;
                    return true;
                }
            }

            popupName = default;
            return false;
        }
        
        [Serializable]
        private struct PopupInfo
        {
            [SerializeField]
            public WorldPlaceType placeType;

            [SerializeField]
            public PopupName popupName;
        }
    }
}