using System.Collections.Generic;
using Services;
using UnityEngine;

namespace Game.App
{
    [CreateAssetMenu(
        fileName = "GameClientServerPack",
        menuName = "App/New GameClientServerPack"
    )]
    public sealed class GameClientServerPack : ServicePackBase
    {
        [SerializeField]
        private string url = "http://localhost";

        [SerializeField]
        private int port = 3000;

        public override IEnumerable<object> ProvideServices()
        {
            var gameServer = new GameServer(this.url, this.port);
            var gameClient = new GameClient(gameServer); 
            
            yield return gameServer;
            yield return gameClient;
        }
    }
}