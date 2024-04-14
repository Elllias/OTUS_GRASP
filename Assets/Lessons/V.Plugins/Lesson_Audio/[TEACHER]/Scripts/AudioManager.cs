// using System.Collections.Generic;
// using Game;
// using UnityEngine;
// // ReSharper disable UnusedMember.Global
// #pragma warning disable CS0169
// #pragma warning disable CS0649
//
// namespace Lessons.PRESENTATION.AUDIOSYSTEM
// {
//     
//     
//     
//     public sealed class AudioManager : MonoBehaviour {
//         
//         private static AudioManager instance;
//
//         [SerializeField] private AudioSource soundSource;
//         [SerializeField] private AudioSource musicSource;
//         [SerializeField] private AudioClip clickSFX;
//
//         public static void PlaySound(AudioClip sound) {
//             instance.soundSource.PlayOneShot(sound);
//         }
//
//         public static void PlayMusic(AudioClip music) {
//             instance.musicSource.clip = music;
//             instance.musicSource.Play();
//         }
//
//         public static void PlayClick() {
//             PlaySound(instance.clickSFX);
//         }
//     }
//
//
//     public sealed class SettingsPopup : MonoBehaviour {
//         
//         private void OnCloseClicked() {
//             //UI logic
//             AudioManager.PlayClick();
//         }
//     }
//
//     public sealed class UpgradesManager : MonoBehaviour {
//         
//         [SerializeField] private AudioClip upgradeSFX;
//         
//         private void LevelUp(IHeroUpgrade upgrade) {
//             //Game logic...
//             AudioManager.PlaySound(this.upgradeSFX);
//         }
//     }
//
//     public sealed class JumpMechanics : MonoBehaviour {
//         
//         [SerializeField] private AudioClip jumpSFX;
//         
//         public void Jump() {
//             //Physics logic...
//             AudioManager.PlaySound(this.jumpSFX);
//         }
//     }
//     
//     
//     
//     
//     public sealed class AudioSourcePool : MonoBehaviour {
//         
//         [SerializeField] private int poolSize = 32;
//         [SerializeField] private AudioSource prefab;
//
//         private readonly Queue<AudioSource> availableSources;
//
//         public AudioSource Get()
//         {
//             var audioSource = this.availableSources.Dequeue();
//             audioSource.enabled = true;
//             return audioSource;
//         }
//
//         public void Release(AudioSource source) {
//             source.enabled = false;
//             this.availableSources.Enqueue(source);
//         }
//     }


// using UnityEngine;
// using UnityEngine.Audio;
//
//     public sealed class AudioManager : MonoBehaviour
//     {
//         private static AudioManager instance;
//
//         [SerializeField]
//         private AudioMixer mixer;
//
//         public static void SetSoundVolume(float volume) => 
//             instance.mixer.SetFloat("SoundVolume", ConvertToDb(volume));
//
//         public static void SetMusicVolume(float volume) => 
//             instance.mixer.SetFloat("MusicVolume", ConvertToDb(volume));
//
//         private static float ConvertToDb(float volume) => 
//             Mathf.Lerp(-80, 0, volume);
//     }






// }