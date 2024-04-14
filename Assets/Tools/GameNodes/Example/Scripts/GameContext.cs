using System;
using System.Collections.Generic;

namespace GameNodes
{
    public sealed class GameContext : GameNode
    {
        private void Awake()
        {
            this.Install();
        }

        private void OnEnable()
        {
            this.Send<GameInit>();
            this.Send<GameStart>();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                this.Send<GamePause>();
            }
            else
            {
                this.Send<GameResume>();
            }
        }

        private void OnDisable()
        {
            this.Send<GameFinish>();
        }

        // public async void Start()
        // {
        //     await this.InstallAsync();
        //     Debug.Log("Installed Async!");
        //     await this.CallAsync<GameInit>();
        //     Debug.Log("Inited Game!");
        //     await this.CallAsync<GameStart>();
        //     Debug.Log("Started Game!");
        // }

        protected override IEnumerable<object> LoadServices()
        {
            yield return new InputSystem();
        }
    }
}