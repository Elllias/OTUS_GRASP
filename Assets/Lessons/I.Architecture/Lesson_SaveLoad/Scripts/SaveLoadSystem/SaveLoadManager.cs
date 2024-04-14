using GameSystem;
using Services;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.SaveLoad
{
    public sealed class SaveLoadManager : MonoBehaviour
    {
        private ISaveLoader[] saveLoaders;
        private GameRepository repository;

        [ServiceInject]
        public void Construct(ISaveLoader[] saveLoaders, GameRepository repository)
        {
            this.saveLoaders = saveLoaders;
            this.repository = repository;
        }

        [Button]
        public void Load() //
        {
            this.repository.LoadState();
            
            GameContext context = FindObjectOfType<GameContext>();
            foreach (var saveLoader in this.saveLoaders)
            {
                saveLoader.LoadGame(this.repository, context);
            }
        }

        [Button]
        public void Save()
        {
            GameContext context = FindObjectOfType<GameContext>();
            foreach (var saveLoader in this.saveLoaders)
            {
                saveLoader.SaveGame(this.repository, context);
            }
            
            this.repository.SaveState();
        }
        
        //TODO: TIMER

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
            {
                this.Save();
            }
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                this.Save();
            }
        }

        private void OnApplicationQuit()
        {
            this.Save();
        }
    }
}