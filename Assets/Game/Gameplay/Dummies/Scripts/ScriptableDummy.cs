using Game.GameEngine;
using UnityEngine;

namespace Game.Gameplay.Dummies
{
    [CreateAssetMenu(
        fileName = "ScriptableDummy",
        menuName = "Gameplay/Dummies/New ScriptableDummy"
    )]
    public sealed class ScriptableDummy : ScriptableObject
    {
        [SerializeField]
        public int hitPoints;

        [SerializeField]
        public string dummyName = "Dummy";

        [SerializeField]
        public ObjectType objectType = ObjectType.ENEMY;
    }
}