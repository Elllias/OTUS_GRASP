using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.Scripts.Application.Configs
{
    [CreateAssetMenu(menuName = "Configs/New UiAssetConfig", fileName = "UiAssetConfig", order = 0)]
    public class UiAssetConfig : ScriptableObject
    {
        [SerializeField] private AssetReference _menuUiAsset;
        [SerializeField] private AssetReference _gameUiAsset;
        
        public AssetReference GetMenuUiAsset()
        {
            return _menuUiAsset;
        }
        
        public AssetReference GetGameUiAsset()
        {
            return _gameUiAsset;
        }
    }
}