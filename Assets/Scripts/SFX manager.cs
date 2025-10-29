using UnityEngine;
using UnityEngine.VFX;

public class SFXmanager : MonoBehaviour
{
    public static SFXmanager instance;
    [SerializeField] private AudioSource AudioObj;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void PlaySFX(AudioClip audioClip, Transform spawnPos, float pitch)
    {
        AudioSource audioSource = Instantiate(AudioObj, spawnPos.position, Quaternion.identity);

        audioSource.clip = audioClip;
        audioSource.pitch = pitch;

        audioSource.Play();

        float lenght = audioSource.clip.length;

        Destroy(audioSource.gameObject, lenght);
    }
}
