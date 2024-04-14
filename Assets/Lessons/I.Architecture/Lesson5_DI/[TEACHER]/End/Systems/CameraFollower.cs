// using System;
// using UnityEngine;
//
// namespace Lessons.Architecture.DI
// {
//     [Serializable]
//     public sealed class CameraFollower : IGameLateUpdateListener
//     {
//         [SerializeField]
//         private Camera targetCamera;
//
//         [SerializeField]
//         private Vector3 offset;
//
//         private IPlayerService playerService;
//
//         [Inject]
//         public void Construct(IPlayerService playerService)
//         {
//             Debug.Log("CONSTRUCT CAMERA FOLLOWER");
//             this.playerService = playerService;
//         }
//
//         void IGameLateUpdateListener.OnLateUpdate(float deltaTime)
//         {
//             var position = this.playerService.GetPlayer().GetPosition();
//             this.targetCamera.transform.position = position + this.offset;
//         }
//     }
// }