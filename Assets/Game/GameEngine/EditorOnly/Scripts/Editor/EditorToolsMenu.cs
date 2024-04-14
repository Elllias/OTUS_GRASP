using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace Game.GameEngine.Development
{
    public static class EditorToolsMenu
    {
        [MenuItem("Tools/GameEngine/Editor Camera")]
        private static void SelectEditorCamera()
        {
            Selection.activeObject = GameObject.FindObjectOfType<EditorCamera>();
        }
    }
}
#endif