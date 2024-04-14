// using System;
// using UnityEngine;
//
// namespace Lessons.Architecture.DI
// {
//     public interface IPlayerService
//     {
//         Player GetPlayer();
//     }
//     
//     [Serializable]
//     public sealed class PlayerService : IPlayerService
//     {
//         [SerializeField]
//         private Player player;
//
//         public Player GetPlayer()
//         {
//             return this.player;
//         }
//     }
// }