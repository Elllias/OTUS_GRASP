using GameSystem;
using Game.GameEngine;
using Game.Gameplay.Player;
using UnityEngine;

namespace Lessons.Tutorial
{
    public sealed class StepObserver_LockInput : StepObserver
    {
        private InputStateManager inputStateManager;

        protected override void InitGame(GameContext context, bool isStepPassed)
        {
            this.inputStateManager = context.GetService<InputStateManager>();
            
            Debug.Log("INIT");
            var currentLayer = isStepPassed
                ? InputStateId.BASE
                : InputStateId.LOCK;
            this.inputStateManager.SwitchState(currentLayer);
        }

        protected override void OnFinishStep()
        {
            Debug.Log("INPUT UNLOCKED");
            this.inputStateManager.SwitchState(InputStateId.BASE);
        }
    }
}