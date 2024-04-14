// using UnityEngine;
//
// namespace Lessons.Architecture.DI
// {
//     public sealed class MoveController : 
//         IGameStartListener,
//         IGameFinishListener
//     {
//         private KeyboardInput input;
//
//         private IPlayerService playerService;
//
//         [Inject]
//         public void Construct(KeyboardInput keyboardInput, IPlayerService playerService)
//         {
//             Debug.Log("CONSTRUCT MOVE CONTROLLER");
//             this.input = keyboardInput;
//             this.playerService = playerService;
//         }
//
//         void IGameStartListener.OnStartGame()
//         {
//             input.OnMove += this.OnMove;
//         }
//
//         void IGameFinishListener.OnFinishGame()
//         {
//             input.OnMove -= this.OnMove;
//         }
//
//         private void OnMove(Vector2 direction)
//         {
//             var offset = new Vector3(direction.x, 0, direction.y) * Time.deltaTime;
//             playerService.GetPlayer().Move(offset);
//         }
//     }
// }