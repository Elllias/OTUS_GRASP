#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Game.Development
{
    public static class SceneMenu
    {
        public const string LOADING_SCENE_PATH = "Assets/Game/Scenes/LoadingScene.unity";

        public const string GAME_SCENE_PATH = "Assets/Game/Scenes/GameScene.unity";
    
        [MenuItem("Scene/Open Loading Scene")]
        private static void OpenLoadingScene()
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.OpenScene(LOADING_SCENE_PATH);
            }
        }

        [MenuItem("Scene/Open Game Scene")]
        private static void OpenGameScene()
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.OpenScene(GAME_SCENE_PATH);
            }
        }
    }
}
#endif