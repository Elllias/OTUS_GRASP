using Game.App;
using Newtonsoft.Json;
using Services;
using UnityEngine;

namespace Game.Tutorial.App
{
    public class TutorialMediator :
        IAppInitListener,
        IAppStartListener,
        IAppQuitListener
    {
        private const string TUTORIAL_PREFS_KEY = "TutorialData";

        [ServiceInject]
        protected TutorialManager tutorialManager;

        void IAppInitListener.Init()
        {
            this.SetupData();
        }

        protected virtual void SetupData()
        {
            if (PlayerPrefs.HasKey(TUTORIAL_PREFS_KEY))
            {
                var json = PlayerPrefs.GetString(TUTORIAL_PREFS_KEY);
                var data = JsonUtility.FromJson<TutorialData>(json);
                this.tutorialManager.Initialize(data.isCompleted, data.stepIndex);
            }
            else
            {
                this.tutorialManager.Initialize();
            }
        }

        void IAppStartListener.Start()
        {
            this.tutorialManager.OnStepFinished += this.OnTutorialStepFinished;
            this.tutorialManager.OnCompleted += this.OnTutorialCompleted;
        }

        void IAppQuitListener.OnQuit()
        {
            this.tutorialManager.OnStepFinished -= this.OnTutorialStepFinished;
            this.tutorialManager.OnCompleted -= this.OnTutorialCompleted;
        }

        private void OnTutorialStepFinished(TutorialStep step)
        {
            var nextStepIndex = this.tutorialManager.IndexOfStep(step) + 1;

            var data = new TutorialData
            {
                isCompleted = false,
                stepIndex = nextStepIndex
            };

            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(TUTORIAL_PREFS_KEY, json);
        }

        private void OnTutorialCompleted()
        {
            var data = new TutorialData
            {
                isCompleted = true,
                stepIndex = this.tutorialManager.IndexOfStep(this.tutorialManager.CurrentStep)
            };

            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(TUTORIAL_PREFS_KEY, json);
        }
    }
}


// public class TutorialMediator : IGameMediator
// {
//     [ServiceInject]
//     protected TutorialManager tutorialManager;
//
//     public virtual void SetupData(GameRepository repository)
//     {
//         if (repository.TryGetData(nameof(TutorialData), out var json))
//         {
//             var data = JsonConvert.DeserializeObject<TutorialData>(json);
//             this.tutorialManager.Initialize(data.isCompleted, data.stepIndex);
//         }
//         else
//         {
//             this.tutorialManager.Initialize();
//         }
//     }
//
//     void IGameMediator.SaveData(GameRepository repository)
//     {
//         var json = JsonConvert.SerializeObject(new TutorialData
//         {
//             isCompleted = this.tutorialManager.IsCompleted,
//             stepIndex = this.tutorialManager.CurrentIndex
//         });
//         
//         repository.SetData(nameof(TutorialData), json);
//     }
// }