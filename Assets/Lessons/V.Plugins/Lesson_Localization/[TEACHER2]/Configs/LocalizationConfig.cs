// using TMPro;
// using UnityEngine;
//
// namespace Lessons.Plugins.LocalizationLesson
// {
//
//     [CreateAssetMenu(
//         fileName = "Localization Config",
//         menuName = "Lessons/New Localization Config"
//     )]
//     public sealed class LocalizationConfig : ScriptableObject
//     {
//         [SerializeField]
//         private LocalizedProperty<int>[] fontSizeOptions;
//
//         [SerializeField]
//         private LocalizedProperty<TMP_FontAsset>[] fontOptions;
//
//         public int GetFontSize(SystemLanguage language)
//         {
//             return this.fontSizeOptions.FindValue(language);
//         }
//
//         public TMP_FontAsset GetFont(SystemLanguage language)
//         {
//             return this.fontOptions.FindValue(language);
//         }
//     }
// }