using UnityEngine;

namespace AI.Blackboards
{
    [AddComponentMenu("AI/Blackboards/Blackboard Injector")]
    public sealed class BlackboardInjector : MonoBehaviour
    {
        [SerializeField]
        private bool injectOnAwake;

        [Space]
        [SerializeField]
        private Transform root;
    
        [SerializeField]
        private UnityBlackboard blackboard;

        private void Awake()
        {
            if (this.injectOnAwake)
            {
                this.InjectBlackboard();
            }
        }

        public void InjectBlackboard()
        {
            var injects = this.root.GetComponentsInChildren<IBlackboardInjective>();
            for (int i = 0, count = injects.Length; i < count; i++)
            {
                var injections = injects[i];
                injections.Blackboard = this.blackboard;
            }
        }
    }
}