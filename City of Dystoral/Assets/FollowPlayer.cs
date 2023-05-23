using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public string sceneToLoad = "NextScene";
    public float lockedRotation = 90f;

    private void Update()
    {
        if (player != null)
        {
            // Calculate direction to the player
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            // Rotate enemy to face the player (always at lockedRotation angle on the Z-axis)
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, lockedRotation);

            // Move enemy towards the player
            transform.position += direction * speed * Time.deltaTime;
        }
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Change scene when the enemy touches the player
            SceneManager.LoadScene(2);
        }
    }
}
