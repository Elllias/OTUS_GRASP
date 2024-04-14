// using System.Collections;
// using Firebase;
// using Functions;
//
// namespace MyLittleUniverse.App
// {
//     public sealed class LoadingTask_InitFirebase : ICoroutineTask
//     {
//         public IEnumerator Routine()
//         {
//             var task = FirebaseApp.CheckAndFixDependenciesAsync();
//             while (!task.IsCompleted)
//             {
//                 yield return null;
//             }
//         }
//     }
// }