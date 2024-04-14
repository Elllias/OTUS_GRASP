// using System;
// using System.Collections.Generic;
// using System.Reflection;
// using UnityEngine;
//
// namespace Lessons.Architecture.DI
// {
//     public abstract class GameModule : MonoBehaviour
//     {
//         public virtual IEnumerable<object> GetServices()
//         {
//             Type type = this.GetType();
//             FieldInfo[] fields = type.GetFields(
//                 BindingFlags.Instance |
//                 BindingFlags.Public |
//                 BindingFlags.NonPublic |
//                 BindingFlags.DeclaredOnly
//             );
//
//             foreach (var field in fields)
//             {
//                 if (field.IsDefined(typeof(Service)))
//                 {
//                     yield return field.GetValue(this);
//                 }
//             }
//         }
//
//         public virtual IEnumerable<IGameListener> GetListeners()
//         {
//             Type type = this.GetType();
//             FieldInfo[] fields = type.GetFields(
//                 BindingFlags.Instance |
//                 BindingFlags.Public |
//                 BindingFlags.NonPublic |
//                 BindingFlags.DeclaredOnly
//             );
//
//             foreach (var field in fields)
//             {
//                 if (field.IsDefined(typeof(Listener)))
//                 {
//                     var value = field.GetValue(this);
//                     if (value is IGameListener gameListener)
//                     {
//                         yield return gameListener;
//                     }
//                 }
//             }
//         }
//
//         public virtual void ResolveDependencies(GameSystem gameSystem)
//         {
//             Type type = this.GetType();
//             FieldInfo[] fields = type.GetFields(
//                 BindingFlags.Instance |
//                 BindingFlags.Public |
//                 BindingFlags.NonPublic |
//                 BindingFlags.DeclaredOnly
//             );
//
//             foreach (var field in fields)
//             {
//                 var target = field.GetValue(this);
//                 gameSystem.Inject(target);
//             }
//         }
//     }
// }