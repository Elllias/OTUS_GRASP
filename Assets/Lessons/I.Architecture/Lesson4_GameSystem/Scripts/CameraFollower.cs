using UnityEngine;

namespace Lessons.Architecture.GameSystem
{
    public sealed class CameraFollower : MonoBehaviour, IGameLateUpdateListener
    {
        [SerializeField]
        private Camera targetCamera;

        [SerializeField]
        private Player player;

        [SerializeField]
        private Vector3 offset;

        void IGameLateUpdateListener.OnLateUpdate(float deltaTime)
        {
            this.targetCamera.transform.position = this.player.GetPosition() + this.offset;
        }
    }
}