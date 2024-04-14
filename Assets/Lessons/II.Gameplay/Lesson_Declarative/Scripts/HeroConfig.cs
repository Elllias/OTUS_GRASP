using UnityEngine;

namespace Lessons.Architecture.Declarative
{
    [CreateAssetMenu(
        fileName = "HeroConfig",
        menuName = "Lessons/New HeroConfig"
    )]
    public sealed class HeroConfig : ScriptableObject
    {
        [SerializeField]
        public int hitPoints;
    }
}