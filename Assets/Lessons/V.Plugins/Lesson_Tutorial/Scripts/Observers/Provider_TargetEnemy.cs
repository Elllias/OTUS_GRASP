using Entities;
using UnityEngine;

namespace Lessons.Tutorial
{
    public sealed class Provider_TargetEnemy : MonoBehaviour
    {
        public MonoEntity TargetEnemy
        {
            get { return this.targetEnemy; }
        }

        [SerializeField]
        private MonoEntity targetEnemy;
    }
}