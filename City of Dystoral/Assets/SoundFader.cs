using UnityEngine;

public class SoundFader : MonoBehaviour
{
    public AudioSource audioSource;
    public Transform playerTransform;
    public float maxDistance = 10f;

    private float initialVolume;

    private void Start()
    {
        initialVolume = audioSource.volume;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        float volume = Mathf.Lerp(initialVolume, 0f, distance / maxDistance);
        audioSource.volume = volume;
    }
}
