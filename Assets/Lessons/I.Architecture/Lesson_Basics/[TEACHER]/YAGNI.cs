// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// // ReSharper disable UnusedMember.Global
// // ReSharper disable UnusedType.Global
// // ReSharper disable EventNeverSubscribedTo.Global
//
// #pragma warning disable CS1998
//
// // ReSharper disable ArrangeTypeModifiers
// // ReSharper disable ArrangeTypeMemberModifiers
//
// namespace Lessons.Architecture.Basics
// {
//     interface IHttpClient
//     {
//         Task<Response> SendRequest(Requiest requiest);
//     }
//
//
//     
//     
//     public sealed class Response
//     {
//     }
//
//     public sealed class Requiest
//     {
//     }
//
//     //EX2
//     
//     
//     interface ScreenManager
//     {
//         event Action<ScreenType> OnScreenChanged;
//
//         void SwitchScreen(ScreenType screen);
//
//         //Don't used!
//         void SwitchToPreviousScreen();
//     }
//
//
//     public enum ScreenType
//     {
//     }
// }

// using System.Collections.Generic;
//
//
//
//     public sealed class PurchasingManager
//     {
//         public void PurchaseProduct(Product product)
//         {
//             //Purchasing logic...
//         }
//
//         public List<PurchasingReceipt> GetHistory()
//         {
//             //Returns history of purchased products...
//         }
//     }