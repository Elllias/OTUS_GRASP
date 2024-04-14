// using Game.App;
// using UnityEngine;
// // ReSharper disable UnusedParameter.Local
// #pragma warning disable CS0649
//
// namespace Lessons.PRESENTATION.ANALYTICS
// {
//     
//     
//     
//     public sealed class AnalyticsManager : MonoBehaviour
//     {
//         private static AnalyticsManager instance; 
//         
//         public static void LogEvent(string eventName, params AnalyticsParameter[] parameters)
//         {
//             instance.LogEventInternal(eventName, parameters);
//         }
//
//         private void LogEventInternal(string eventName, AnalyticsParameter[] parameters)
//         {
//             //Send event to plugins:
//             //Appmetrica, Firebase, GameAnalytics
//         }
//     }
//     
//     
//     
//     
//     
// }