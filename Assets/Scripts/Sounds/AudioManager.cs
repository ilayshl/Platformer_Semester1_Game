using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource backgroundMusic;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic(AudioClip playMusic){
        backgroundMusic.PlayOneShot(playMusic);
    }
    
    public void PlaySound(AudioClip playAudio){
        audioSource.PlayOneShot(playAudio);
    }
}
