using UnityEngine;

namespace Lessons.Architecture.DI
{
    public sealed class PlayerInstaller : GameInstaller
    {
        [SerializeField, Listener]
        private CameraFollower cameraFollower;
        
        [Listener]
        private readonly MoveController moveController = new();
        
        [Listener, Service(typeof(IMoveInput))]
        private readonly KeyboardInput keyboardInput = new();
    }
}