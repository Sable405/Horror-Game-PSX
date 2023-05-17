using UnityEngine;

public class FaceAndMoveTowardsPlayer : MonoBehaviour
{
    public Transform player;
    public float movementSpeed = 5f;
    public float rotationSpeed = 90f;
    public float detectionRange = 10f;
    public bool lockRotationOnZ = true;

    private void Update()
    {
        // Calculate the distance between the object and the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the detection range
        if (distanceToPlayer <= detectionRange)
        {
            // Face the player
            Vector3 targetDirection = player.position - transform.position;
            targetDirection.y = 0f;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            
            if (lockRotationOnZ)
            {
                // Lock rotation on the Z-axis
                targetRotation.eulerAngles = new Vector3(targetRotation.eulerAngles.x, targetRotation.eulerAngles.y, 90f);
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
        }
    }
}
