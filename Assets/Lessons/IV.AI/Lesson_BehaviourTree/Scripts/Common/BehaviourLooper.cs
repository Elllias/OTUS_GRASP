using UnityEngine;

namespace Lessons.AI.LessonBehaviourTree
{
    public sealed class BehaviourLooper : MonoBehaviour
    {
        [SerializeField]
        private BehaviourNode root;

        private void FixedUpdate()
        {
            if (!this.root.IsRunning)
            {
                this.root.Run(null);
            }
        }
    }
}