using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Plugins.LocalizationLesson
{
    [CreateAssetMenu(
        fileName = "TextDictionary",
        menuName = "Lessons/New TextDictionary"
    )]
    public sealed class TextDictionary : LocalizationDictionary<string>
    {
        [SerializeField, TextArea, PropertyOrder(-10)]
        public string uri;
    }
}