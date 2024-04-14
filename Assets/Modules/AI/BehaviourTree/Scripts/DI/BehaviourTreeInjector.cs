using UnityEngine;

namespace AI.BTree
{
    public sealed class BehaviourTreeInjector : MonoBehaviour
    {
        [SerializeField]
        private bool injectOnAwake = true;

        [Space]
        [SerializeField]
        private Transform root;

        [SerializeField]
        private UnityBehaviourTree behaviourTree;

        private void Awake()
        {
            if (this.injectOnAwake)
            {
                this.InjectBehaviourTree();
            }
        }

        public void InjectBehaviourTree()
        {
            var injects = this.root.GetComponentsInChildren<IBehaviourTreeInjective>();
            for (int i = 0, count = injects.Length; i < count; i++)
            {
                var injections = injects[i];
                injections.Tree = this.behaviourTree;
            }
        }
    }
}