// using UnityEngine;
//
// namespace Lessons.Plugins.LocalizationLesson
// {
//     public static class Extensions
//     {
//         public static bool FindValue(this LocalizedString[] translations, SystemLanguage language, out string result)
//         {
//             for (int i = 0, count = translations.Length; i < count; i++)
//             {
//                 var translation = translations[i];
//                 if (translation.language == language)
//                 {
//                     result = translation.value;
//                     return true;
//                 }
//             }
//
//             result = default;
//             return false;
//         }
//         
//         public static bool FindValue(this LocalizedInt[] translations, SystemLanguage language, out int result)
//         {
//             for (int i = 0, count = translations.Length; i < count; i++)
//             {
//                 var translation = translations[i];
//                 if (translation.language == language)
//                 {
//                     result = translation.value;
//                     return true;
//                 }
//             }
//
//             result = default;
//             return false;
//         }
//     }
// }