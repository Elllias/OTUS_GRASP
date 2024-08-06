using UnityEngine.AddressableAssets;

namespace SampleGame
{
    public sealed class SceneLoader
    {
        public void LoadGame()
        {
            Addressables.LoadSceneAsync("Game");
        }

        public void LoadMenu()
        {
            Addressables.LoadSceneAsync("Menu");
        }
    }
}