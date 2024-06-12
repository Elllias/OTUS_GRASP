using UnityEngine;

//Менять нельзя!
public sealed class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance { get; private set; }

    [SerializeField]
    private AudioSource soundSource;
    
    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(AudioClip sound)
    {
        this.soundSource.PlayOneShot(sound);
    }
}
