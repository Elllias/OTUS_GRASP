// using Asyncoroutine;
// using UnityEngine;
//
// namespace Lessons.Architecture.DI
// {
//     public sealed class PlayerModule : GameModule
//     {
//         [Listener]
//         [SerializeField]
//         private CameraFollower cameraFollower;
//
//         [Service]
//         [SerializeField]
//         private PlayerService playerService;
//         
//         [Listener]
//         private readonly MoveController moveController = new MoveController();
//
//         [Service, Listener]
//         private readonly KeyboardInput keyboardInput = new KeyboardInput();
//     }
// }