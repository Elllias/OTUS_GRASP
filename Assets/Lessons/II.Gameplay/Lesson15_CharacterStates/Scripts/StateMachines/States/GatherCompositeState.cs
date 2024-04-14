using System;
using Declarative;
using Lessons.Character.Model;

namespace Lessons.StateMachines.States
{
    [Serializable]
    public sealed class GatherCompositeState : CompositeState
    {
        public GatheringTimerState timerState;
        public GatheringDistanceState distanceState;

        [Construct]
        public void ConstructSelf()
        {
            SetStates(timerState, distanceState);
        }
        
        [Construct]
        public void ConstructSubStates(CharacterMovement movement, CharacterGathering gathering)
        {
            timerState.Construct(gathering.duration, gathering.process);
            distanceState.Construct(movement.transform, gathering.process, gathering.minDistance);
        }
    }
}