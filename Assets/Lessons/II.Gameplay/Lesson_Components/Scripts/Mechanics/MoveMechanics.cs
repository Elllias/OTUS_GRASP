using UnityEngine;

namespace Lessons.Architecture.Components
{
    public sealed class MoveMechanics : MonoBehaviour
    {
        [SerializeField]
        private Vector3EventReceiver moveReceiver;

        [SerializeField]
        private Transform moveTransform;

        private void OnEnable()
        {
            this.moveReceiver.OnEvent += this.OnMove;
        }

        private void OnDisable()
        {
            this.moveReceiver.OnEvent -= this.OnMove;
        }

        private void OnMove(Vector3 moveVector)
        {
            this.moveTransform.position += moveVector;
        }
    }
}