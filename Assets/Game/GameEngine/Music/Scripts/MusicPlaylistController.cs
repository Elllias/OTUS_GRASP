using System.Collections;
using GameSystem;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class MusicPlaylistController : MonoBehaviour,
        IGameStartElement,
        IGameFinishElement
    {
        [SerializeField]
        private MusicPlaylist playlist;
        
        [SerializeField]
        private float pauseBetweenTracks = 1.5f;

        private int trackPointer;

        void IGameStartElement.StartGame()
        {
            MusicManager.OnFinsihed += this.OnMusicFinished;
            
            var track = this.playlist.trackList[0];
            MusicManager.Play(track);
        }

        void IGameFinishElement.FinishGame()
        {
            MusicManager.OnFinsihed -= this.OnMusicFinished;
            MusicManager.Stop();
        }

        private void OnMusicFinished()
        {
            this.trackPointer++;
            if (this.trackPointer >= this.playlist.trackList.Length)
            {
                this.trackPointer = 0;
            }

            this.StartCoroutine(this.PlayNextTrack());
        }

        private IEnumerator PlayNextTrack()
        {
            yield return new WaitForSeconds(this.pauseBetweenTracks);
            var nextTrack = this.playlist.trackList[this.trackPointer];
            MusicManager.Play(nextTrack);
        }
    }
}