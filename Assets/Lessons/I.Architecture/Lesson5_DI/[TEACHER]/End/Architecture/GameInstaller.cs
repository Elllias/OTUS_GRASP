// using UnityEngine;
//
// namespace Lessons.Architecture.DI
// {
//     [RequireComponent(typeof(GameSystem))]
//     public sealed class GameInstaller : MonoBehaviour
//     {
//         [SerializeField]
//         private GameModule[] modules;
//
//         private GameSystem gameSystem;
//         
//         private void Awake()
//         {
//             this.gameSystem = this.GetComponent<GameSystem>();
//             this.InstallServices();
//             this.InstallListeners();
//             this.ResolveDependencies();
//         }
//
//         private void InstallServices()
//         {
//             foreach (var module in this.modules)
//             {
//                 var services = module.GetServices(); //C#
//                 this.gameSystem.AddServices(services);
//             }
//         }
//
//         private void InstallListeners()
//         {
//             foreach (var module in this.modules)
//             {
//                 var listeners = module.GetListeners();
//                 this.gameSystem.AddListeners(listeners);
//             }
//         }
//
//         private void ResolveDependencies()
//         {
//             foreach (var module in this.modules)
//             {
//                 module.ResolveDependencies(this.gameSystem);
//             }
//         }
//     }
// }