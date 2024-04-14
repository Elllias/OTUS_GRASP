using UnityEngine;

namespace Lessons.AI.HierarchicalStateMachine
{
    public sealed class AIStateController : MonoBehaviour
    {
        [SerializeField]
        private AIState rootState;

        private void OnEnable()
        {
            this.rootState.OnEnter();
        }

        private void FixedUpdate()
        {
            this.rootState.OnUpdate();
        }

        private void OnDisable()
        {
            this.rootState.OnExit();
        }
    }
}