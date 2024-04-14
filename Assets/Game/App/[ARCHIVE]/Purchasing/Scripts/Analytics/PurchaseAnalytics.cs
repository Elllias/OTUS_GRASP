// using System;
// using UnityEngine;
// using UnityEngine.Purchasing;
//
// #pragma warning disable 618
//
// namespace MyLittleUniverse.App
// {
//     public static class PurchaseAnalytics
//     {
//         public static void LogReceipt(Product product)
//         {
//             LogAppmetricaReceipt(product);
//         }
//
//         private static void LogAppmetricaReceipt(Product product)
//         {
//             var currency = product.metadata.isoCurrencyCode;
//             var price = decimal.ToDouble(product.metadata.localizedPrice);
//             var revenue = new YandexAppMetricaRevenue(price, currency);
//             if (product.receipt != null)
//             {
//                 var yaReceipt = new YandexAppMetricaReceipt();
//                 var receipt = JsonUtility.FromJson<Receipt>(product.receipt);
// #if UNITY_ANDROID
//                 var payload = receipt.Payload;
//                 var payloadAndroid = JsonUtility.FromJson<PayloadAndroid>(payload);
//                 yaReceipt.Signature = payloadAndroid.Signature;
//                 yaReceipt.Data = payloadAndroid.Json;
// #elif UNITY_IPHONE
//                 yaReceipt.TransactionID = receipt.TransactionID;
//                 yaReceipt.Data = receipt.Payload;
// #endif
//                 revenue.Receipt = yaReceipt;
//                 AppMetrica.Instance.ReportRevenue(revenue);
//             }
//         }
//
//         [Serializable]
//         public struct Receipt
//         {
//             [SerializeField]
//             public string Store;
//
//             [SerializeField]
//             public string TransactionID;
//
//             [SerializeField]
//             public string Payload;
//         }
//
//         [Serializable]
//         public struct PayloadAndroid
//         {
//             [SerializeField]
//             public string Json;
//
//             [SerializeField]
//             public string Signature;
//         }
//     }
// }