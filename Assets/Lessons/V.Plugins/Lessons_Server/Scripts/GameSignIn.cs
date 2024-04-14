using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Game.App;
using Game.UI;
using Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Plugins.Lesson_Server
{
    //Domain:
    public sealed class GameSignIn : MonoBehaviour
    {
        private GameClient gameClient;
        private GameSaver gameSaver;
        private GameRepository repository;
        private GameLauncher gameLauncher;

        [ServiceInject]
        public void Construct(GameClient gameClient, GameSaver gameSaver, GameRepository repository, GameLauncher gameLauncher)
        {
            this.gameClient = gameClient;
            this.gameSaver = gameSaver;
            this.repository = repository;
            this.gameLauncher = gameLauncher;
        }
        
        [Button]
        public async void SignIn(string login, string password)
        {
            LoadingScreen.Show();
            this.gameSaver.IsPaused = true;

            await this.AuthorizeInternal(login, password);
            
            this.gameSaver.IsPaused = false;
            LoadingScreen.Hide();
        }

        private async UniTask AuthorizeInternal(string login, string password)
        {   
            if (!await this.gameClient.SignIn(login, password))
            {
                Debug.LogError("Invalid login or password");
                return;
            }

            if (!await this.repository.LoadRemoteState())
            {
                Debug.LogError("Can't load remote state");
                return;
            }

            await this.gameLauncher.LaunchGame();
        }
    }
}