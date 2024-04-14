using Entities;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Declarative
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField]
        private MonoEntityStd unit;

        [Button]
        public void MoveLeft()
        {
            this.Move(Vector3.left);
        }

        [Button]
        private void MoveRight()
        {
            this.Move(Vector3.right);
        }

        private void Move(Vector3 direction)
        {
            this.unit.Get<IMoveComponent>().Move(direction);
        }
    }
}