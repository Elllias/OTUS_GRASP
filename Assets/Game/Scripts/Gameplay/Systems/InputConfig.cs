using UnityEngine;

namespace SampleGame
{
    [CreateAssetMenu(
        fileName = "InputConfig",
        menuName = "Gameplay/New InputConfig"
    )]
    public sealed class InputConfig : ScriptableObject
    {
        public KeyCode left;
        public KeyCode right;
        public KeyCode forward;
        public KeyCode back;
    }
}