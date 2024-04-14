using UnityEngine;

namespace Lessons.Architecture.DI
{
    public sealed class CharacterInstaller : GameInstaller
    {
        [SerializeField, Service(typeof(Character))]
        private Character character;
    }
}