using System.Threading.Tasks;
using Asyncoroutine;
using GameSystem;
using UnityEngine;

namespace Game.GameEngine.GUI
{
    public static class GameInterfaceDeployer
    {
        private const string OBJECT_NAME = "[GAME_INTERFACE]";

        public static async Task DeployInterface(GameContext gameContext)
        {
            var handle = Resources.LoadAsync<GameObject>("GameInterface");
            await new WaitUntil(() => handle.isDone);

            var prefab = (GameObject) handle.asset;
            var gameInteface = GameObject.Instantiate(prefab);
            gameInteface.name = OBJECT_NAME;

            var gameElement = gameInteface.GetComponent<IGameElementGroup>();
            gameContext.RegisterElement(gameElement);

            var gameService = gameInteface.GetComponent<IGameServiceGroup>();
            gameContext.RegisterService(gameService);
        }
    }
}