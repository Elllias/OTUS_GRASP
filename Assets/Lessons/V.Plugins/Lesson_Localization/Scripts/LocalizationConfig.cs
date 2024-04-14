using TMPro;
using UnityEngine;

namespace Lessons.Plugins.LocalizationLesson
{
    [CreateAssetMenu(
        fileName = "LocalizationConfig",
        menuName = "Lessons/New LocalizationConfig"
    )]
    public sealed class LocalizationConfig : ScriptableObject
    {
        [SerializeField]
        public LocalizedProperty<int>[] fontSizes;

        [SerializeField]
        public LocalizedProperty<TMP_FontAsset>[] fonts;
    }
}