#if UNITY_EDITOR

using UnityEditor;
using UnityEditor.SceneManagement;

namespace Game.Development
{
    public sealed class ApplicationMenu
    {
        [MenuItem("Tools/Play Game")]
        private static void Play()
        {
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                var name = EditorSceneManager.GetActiveScene().name;
                if (name != "LoadingScene")
                {
                    EditorSceneManager.OpenScene(SceneMenu.LOADING_SCENE_PATH);
                }

                EditorApplication.isPlaying = true;
            }
        }
    }
}
#endif