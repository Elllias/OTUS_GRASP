using System;
using Lessons.Gameplay.Interaction;
using Lessons.Utils;
using UnityEngine;

namespace Lessons.StateMachines.States
{
    [Serializable]
    public sealed class GatheringDistanceState : UpdateState
    {
        private Transform myTransform;
        private AtomicProcess<GatherResourceCommand> process;
        private AtomicVariable<float> minDistance;

        public void Construct(
            Transform myTransform,
            AtomicProcess<GatherResourceCommand> process,
            AtomicVariable<float> minDistance
        )
        {
            this.myTransform = myTransform;
            this.process = process;
            this.minDistance = minDistance;
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (Vector3.Distance(this.myTransform.position, process.State.Position) > this.minDistance.Value)
            {
                process.Stop();
            }
        }
    }
}