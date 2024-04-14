using UnityEngine;

namespace Lessons.Plugins.LocalizationLesson
{
    [CreateAssetMenu(
        fileName = "SpriteDictionary",
        menuName = "Lessons/New SpriteDictionary"
    )]
    public sealed class SpriteDictionary : LocalizationDictionary<Sprite>
    {
    }
}