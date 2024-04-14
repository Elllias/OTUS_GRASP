using System;
using Elementary;
using UnityEngine;

namespace Lessons.Gameplay.Mech
{
    public sealed class ConveyorWorkMechanics : MonoBehaviour
    {
        [Space]
        [SerializeField]
        private MonoTimer workTimer;

        [SerializeField]
        private MonoIntVariableLimited inputStorage;

        [SerializeField]
        private MonoIntVariableLimited outputStorage;

        private void OnEnable()
        {
            this.workTimer.OnFinished += this.OnWorkFinished;
        }

        private void OnDisable()
        {
            this.workTimer.OnFinished -= this.OnWorkFinished;
        }

        private void Update()
        {
            if (this.CanStartWork())
            {
                this.StartWork();
            }
        }

        private bool CanStartWork()
        {
            if (this.inputStorage.Current <= 0)
            {
                return false;
            }

            if (this.outputStorage.IsLimit)
            {
                return false;
            }

            if (this.workTimer.IsPlaying)
            {
                return false;
            }
            
            return true;
        }

        private void StartWork()
        {
            this.inputStorage.Current--;
            this.workTimer.ResetTime();
            this.workTimer.Play();
        }

        private void OnWorkFinished()
        {
            this.outputStorage.Current++;
        }
    }
}