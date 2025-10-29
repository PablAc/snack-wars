using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    AudioSource musicSource;
    [SerializeField] AudioClip[] musicClips;

    private void Awake()
    {
        if (instance == null) instance = this;
        musicSource = this.GetComponent<AudioSource>();
        PlayMusic(0, 0.15f);
    }
    public void PlayMusic(int musicTrackID, float volume)
    {
        ;
        musicSource.Stop();
        musicSource.clip = musicClips[musicTrackID];
        musicSource.volume = volume;
        musicSource.Play();
    }
    public void StopMusic()
    {
        musicSource.Stop();
    }
}
