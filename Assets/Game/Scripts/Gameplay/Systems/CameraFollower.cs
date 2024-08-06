using UnityEngine;
using Zenject;

namespace SampleGame
{
    public sealed class CameraFollower : ILateTickable
    {
        private readonly ICharacter character;
        private readonly Camera camera;
        private readonly Vector3 cameraOffset;

        public CameraFollower(ICharacter character, Camera camera, Vector3 cameraOffset)
        {
            this.character = character;
            this.camera = camera;
            this.cameraOffset = cameraOffset;
        }

        void ILateTickable.LateTick()
        {
            var cameraPosition = this.character.GetPosition() + this.cameraOffset;
            this.camera.transform.position = cameraPosition;
        }
    }
}