using LocalizationModule;
using UnityEngine;

namespace Game.Localization
{
    [CreateAssetMenu(
        fileName = "LocalizationSpriteConfig",
        menuName = "Localization/New LocalizationSpriteConfig"
    )]
    public sealed class LocalizationSpriteConfig : ScriptableObject
    {
        [SerializeField]
        public SpriteEntity[] entities;
    }
}