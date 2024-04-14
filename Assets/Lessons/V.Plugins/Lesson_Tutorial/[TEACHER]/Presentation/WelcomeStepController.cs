// // ReSharper disable UnusedType.Global
//
// using System;
// using System.Collections.Generic;
// using Game.Tutorial.UI;
//
// // ReSharper disable UnusedMember.Global
// // ReSharper disable UnassignedGetOnlyAutoProperty
// // ReSharper disable EventNeverSubscribedTo.Global
// #pragma warning disable CS0067
//
// #pragma warning disable CS0169
//
// namespace Lessons.PRESENTATION.TUTORIAL
// {
//     // public class TutorialManager
//     // {
//     //     public event Action OnCompleted;
//     //     public event Action<int> OnStepFinished;
//     //     
//     //     public bool IsCompleted { get; private set; }
//     //     public int CurrentStep { get; private set; }
//     //     private readonly List<ITutorialStep> steps;
//     //     
//     //     public TutorialManager(List<ITutorialStep> steps) => this.steps = steps;
//     //
//     //     public void Run() => this.RunStep();
//     //
//     //     private void RunStep() {
//     //         int stepIndex = this.CurrentStep - 1;
//     //         ITutorialStep targetStep = this.steps[stepIndex];
//     //         targetStep.Run(this.OnFinishStep);
//     //     }
//     //
//     //     private void OnFinishStep() {
//     //         this.OnStepFinished?.Invoke(this.CurrentStep);
//     //         this.CurrentStep++;
//     //         if (this.CurrentStep >= this.steps.Count) {
//     //             this.IsCompleted = true;
//     //             this.OnCompleted?.Invoke();
//     //         }
//     //         else {
//     //             this.RunStep();
//     //         }
//     //     }
//     // }
//     //
//     //
//     // public interface ITutorialStep
//     // {
//     //     void Run(Action onComplete);
//     // }
//     //
//     // public sealed class TutorialStep_Welcome : ITutorialStep 
//     // {
//     //     private PopupManager popupManager;
//     //     
//     //     public void Run(Action onComplete)
//     //     {
//     //         //TODO: Show welcome popup
//     //     }
//     // }
//     //
//     // public sealed class TutorialStep_KillDragon : ITutorialStep
//     // {
//     //     private Dragon dragon;
//     //
//     //     public void Run(Action onComplete)
//     //     {
//     //         //TODO: Kill enemies quest
//     //     }
//     // }
//     //
//     // public sealed class TutorialStep_SavePrincess : ITutorialStep
//     // {
//     //     private Princess dragon;
//     //     private Key key;
//     //
//     //     public void Run(Action onComplete)
//     //     {
//     //         //TODO: Come to a princess
//     //     }
//     // }
//     //
//     //
//     //
//
//     public sealed class WelcomeStepController
//     {
//         private TutorialState tutorialState;
//         private PopupManager popupManager;
//
//         public WelcomeStepController(
//             TutorialState tutorialState,
//             PopupManager popupManager
//         ) {
//             this.tutorialState = tutorialState;
//             this.popupManager = popupManager;
//             this.tutorialState.OnStepStarted += this.OnStart;
//         }
//
//         private void OnStart(TutorialStep step) {
//             if (step != TutorialStep.WELCOME) return;
//             this.popupManager.ShowWelcomePopup(() =>
//                 this.tutorialState.FinishStep());
//         }
//     }
//
//     public enum TutorialStep
//     {
//         START = -1,
//         WELCOME = 0,
//         KILL_DRAGON = 1,
//         SAVE_PRINCESS = 2,
//         END = 3
//     }
//
//     public sealed class TutorialState
//     {
//         public event Action<TutorialStep> OnStepStarted;
//         public event Action<TutorialStep> OnStepFinished;
//         public event Action OnCompleted;
//
//         public bool IsCompleted { get; private set; }
//         public TutorialStep CurrentStep { get; private set; } = TutorialStep.START;
//
//         public void NextStep()
//         {
//             this.CurrentStep++;
//             if (this.CurrentStep == TutorialStep.END)
//             {
//                 this.IsCompleted = true;
//                 this.OnCompleted?.Invoke();
//             }
//             else
//             {
//                 this.OnStepStarted?.Invoke(this.CurrentStep);
//             }
//         }
//
//         public void FinishStep(bool moveNext = true)
//         {
//             this.OnStepFinished?.Invoke(this.CurrentStep);
//             if (moveNext) this.NextStep();
//         }
//     }
//
//
//     //
//     //
//     //
//     // public sealed class TutorialStep_1Welcome : TutorialStep
//     // {
//     //     //TODO: Show welcome popup
//     // }
//     //
//     // public sealed class TutorialStep_2KillDragon : TutorialStep
//     // {
//     //     //TODO: Kill enemies quest
//     // }
//     //
//     // public sealed class TutorialStep_3SavePrincess : TutorialStep
//     // {
//     //     //TODO: Come to a princess
//     // }
// }