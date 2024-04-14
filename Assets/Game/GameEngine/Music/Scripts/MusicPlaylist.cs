using UnityEngine;

namespace Game.GameEngine
{
    [CreateAssetMenu(
        fileName = "MusicConfig",
        menuName = "Gameplay/Audio/New MusicConfig"
    )]
    public sealed class MusicPlaylist : ScriptableObject
    {
        [SerializeField]
        public AudioClip[] trackList;
    }
}