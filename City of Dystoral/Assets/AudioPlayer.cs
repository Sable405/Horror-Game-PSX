using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        
        // Set the audio clip to play
        audioSource.clip = audioClip;
    }

    private void Update()
    {

    }
}
