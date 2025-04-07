using UnityEngine;


//werkt voor nu alleen samen met I_Geluid om geluid af te spelen door een audio source op de objecten te zetten
public class AudioManager : MonoBehaviour, IGeluid
{
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void SpeelGeluidAf(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
