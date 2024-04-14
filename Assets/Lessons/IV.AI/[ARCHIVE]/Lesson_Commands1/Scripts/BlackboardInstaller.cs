using AI.Blackboards;
using Entities;
using UnityEngine;
using Blackboard = Lessons.AI.HierarchicalStateMachine.Blackboard;

namespace Lessons.AI.Lesson_Commands1
{
    public sealed class BlackboardInstaller : MonoBehaviour
    {
        [SerializeField]
        private Blackboard blackboard;

        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [SerializeField]
        private MonoEntity unit;

        [BlackboardKey]
        [SerializeField]
        private string stoppingDistanceKey;

        [SerializeField]
        private float stoppingDistance = 0.5f;

        private void Awake()
        {
            this.blackboard.SetVariable(this.unitKey, this.unit);
            this.blackboard.SetVariable(this.stoppingDistanceKey, this.stoppingDistance);
        }
    }
}