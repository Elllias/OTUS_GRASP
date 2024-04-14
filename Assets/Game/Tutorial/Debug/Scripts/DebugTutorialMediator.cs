#if UNITY_EDITOR
using Game.Tutorial.App;
using JetBrains.Annotations;
using Services;
using UnityEngine;

namespace Game.Tutorial.Development
{
    [UsedImplicitly]
    public sealed class DebugTutorialMediator : TutorialMediator
    {
        protected override void SetupData()
        {
            var debugConfig = DebugTutorialConfig.Instance;
            if (debugConfig.isDebug)
            {
                this.tutorialManager.Initialize(debugConfig.isCompleted, (int) debugConfig.currentStep);
            }
            else
            {
                base.SetupData();
            }
        }
    }
}
#endif