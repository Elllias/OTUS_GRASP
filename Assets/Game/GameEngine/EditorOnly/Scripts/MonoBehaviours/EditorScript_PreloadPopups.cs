using UnityEngine;

#if UNITY_EDITOR

namespace Game.GameEngine.Development
{
    public sealed class EditorScript_PreloadPopups : MonoBehaviour
    {
        [SerializeField]
        private PopupCatalog popupCatalog;
        
        public async void PreloadPrefabs()
        {
            await this.popupCatalog.LoadAssets();
        }
    }
}

#endif