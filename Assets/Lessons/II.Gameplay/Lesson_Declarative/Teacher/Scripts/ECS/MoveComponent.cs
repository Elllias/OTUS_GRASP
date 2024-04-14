// using UnityEngine;
//
// namespace Lessons.I.Architecture.Lesson_Declarative.Teacher.Scripts.ECS
// {
//     public struct TransformData
//     {
//         public Vector3 position;
//         public Quaternion rotation;
//     }
//     
//     public struct MoveSpeedData
//     {
//         public float speed;
//     }
//
//     public struct MoveRequest
//     {
//         public Vector3 direction;
//     }
//
//     public sealed class MoveSystem
//     {
//         private Filter<TransformData, MoveSpeedData, MoveRequest> filter;
//         
//         public void Update()
//         {
//             foreach (var entity in filter)
//             {
//                 this.Move(entity);
//             }
//         }
//
//         private void Move(Entity entity)
//         {
//             ref TransformData transformData = ref entity.Get<TransformData>();
//             ref MoveSpeedData speedData = ref entity.Get<MoveSpeedData>();
//             ref MoveRequest moveRequest = ref entity.Get<MoveRequest>();
//
//             var offset = moveRequest.direction * speedData.speed;
//             transformData.position += offset;
//         }
//     }
// }