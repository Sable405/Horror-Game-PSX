using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
 public Transform playerTransform; // the player's transform, which we'll follow
    public float moveSpeed = 5f; // the speed at which we'll move towards the player
    public float hitDistance = 0.5f; // the distance at which we'll consider ourselves "hit" by the player
    public int hitPoints = 3; // the number of hit points the enemy has before it's destroyed

    private bool isHit = false; // whether we've been hit by the player or not
    private int currentHitPoints; // the current number of hit points we have left

    void Start()
    {
        currentHitPoints = hitPoints; // set the initial number of hit points
    }

    void Update()
    {
        // if we've been hit, don't do anything
        if (isHit)
            return;

        // calculate the direction to the player
        Vector3 directionToPlayer = playerTransform.position - transform.position;

        // rotate to face the player
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);
        targetRotation *= Quaternion.Euler(0f, 0f, 90f);
        transform.rotation = targetRotation;

        // move towards the player at the specified speed
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);

        // if we're close enough to the player, consider ourselves "hit"
        if (Vector3.Distance(transform.position, playerTransform.position) <= hitDistance)
        {
            isHit = true;
            currentHitPoints--;
            Debug.Log("Enemy hit! Remaining hit points: " + currentHitPoints);

            // if we've run out of hit points, destroy ourselves
            if (currentHitPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
