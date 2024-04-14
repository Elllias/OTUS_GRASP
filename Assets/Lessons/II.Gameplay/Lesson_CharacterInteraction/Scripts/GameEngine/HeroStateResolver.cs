using Game.GameEngine.Mechanics;
using UnityEngine;
using HarvestResourceOperation = Lessons.Gameplay.CharacterInteraction.HarvestResourceOperation;

namespace Lessons.Gameplay.Lesson_CharacterInteraction
{
    public sealed class HeroStateResolver : MonoBehaviour
    {
        [SerializeField]
        private HeroStateMachine stateMachine;

        [Space]
        [SerializeField]
        private UMoveInDirectionMotor moveEngine;

        [SerializeField]
        private HarvestResourceEngine harvestEngine;

        private void OnEnable()
        {
            this.moveEngine.OnStartMove += this.OnMoveStarted;
            this.moveEngine.OnStopMove += this.OnMoveFinished;
            this.harvestEngine.OnStarted += this.OnHarvestStarted;
            this.harvestEngine.OnStopped += this.OnHarvestFinished;
        }

        private void OnDisable()
        {
            this.moveEngine.OnStartMove -= this.OnMoveStarted;
            this.moveEngine.OnStopMove -= this.OnMoveFinished;
            this.harvestEngine.OnStarted -= this.OnHarvestStarted;
            this.harvestEngine.OnStopped -= this.OnHarvestFinished;
        }

        private void OnMoveStarted()
        {
            if (this.stateMachine.CurrentState == HeroStateType.IDLE)
            {
                this.stateMachine.SwitchState(HeroStateType.MOVE);
            }
        }

        private void OnMoveFinished()
        {
            if (this.stateMachine.CurrentState == HeroStateType.MOVE)
            {
                this.stateMachine.SwitchState(HeroStateType.IDLE);
            }
        }

        private void OnHarvestStarted(HarvestResourceOperation operation)
        {
            if (this.stateMachine.CurrentState is HeroStateType.IDLE or HeroStateType.MOVE)
            {
                this.stateMachine.SwitchState(HeroStateType.HARVEST);
            }
        }

        private void OnHarvestFinished(HarvestResourceOperation operation)
        {
            if (this.stateMachine.CurrentState == HeroStateType.HARVEST)
            {
                this.stateMachine.SwitchState(HeroStateType.IDLE);
            }
        }
    }
}
//         
// [SerializeField]
// private HarvestResourceEngine harvestEngine;

//
// private void OnHarvestStarted(HarvestResourceOperation operation)
// {
//     this.stateMachine.SwitchState(HeroStateType.HARVEST);
// }
//
// private void OnHarvestFinished(HarvestResourceOperation operation)
// {
//     if (this.stateMachine.CurrentState == HeroStateType.HARVEST)
//     {
//         this.stateMachine.SwitchState(HeroStateType.IDLE);
//     }
// }