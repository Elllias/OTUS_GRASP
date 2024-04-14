#if UNITY_EDITOR
using GameSystem;
using UnityEditor;
using UnityEngine;

namespace Game.GameEngine.Development
{
    public sealed class EditorScript_InstallGUI : MonoBehaviour
    {
        public void LoadInteface()
        {
            var gameContext = FindObjectOfType<GameContext>();

            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Game/UI/GameInterface/GameInterface.prefab");
            var gameInteface = Instantiate(prefab);
            gameInteface.name = "[GAME_INTERFACE]";

            var gameElement = gameInteface.GetComponent<IGameElementGroup>();
            gameContext.RegisterElement(gameElement);

            var gameService = gameInteface.GetComponent<IGameServiceGroup>();
            gameContext.RegisterService(gameService);
        }
    }
}
#endif