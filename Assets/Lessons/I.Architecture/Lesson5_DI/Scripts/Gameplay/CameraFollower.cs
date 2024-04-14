using System;
using UnityEngine;

namespace Lessons.Architecture.DI
{
    [Serializable]
    public sealed class CameraFollower : IGameLateUpdateListener
    {
        [SerializeField]
        private Camera targetCamera;

        [SerializeField]
        private Vector3 offset;

        private Character character;

        [Inject]
        public void Construct(Character character)
        {
            Debug.Log("CONSTRUCT CAMERA");
            this.character = character;
        }

        void IGameLateUpdateListener.OnLateUpdate(float deltaTime)
        {
            var cameraPosition = this.character.GetPosition() + this.offset;
            this.targetCamera.transform.position = cameraPosition;
        }
    }
}