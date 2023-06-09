using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Define the controller variable
    private UnityEngine.CharacterController controller;

    // Speed of forwards and backwards movement
    [Range(0.5f, 20)] public float walkSpeed;

    // Speed of sideways (left and right) movement
    [Range(0.5f, 15)] public float strafeSpeed;

    public KeyCode sprintKey;

    // How many times faster movement along the X and Z axes
    // is when sprinting
    [Range(1, 3)] public float sprintFactor;

    [Range(0.5f, 10)] public float jumpHeight;
    public int maxJumps;

    private Vector3 velocity = Vector3.zero;
    private int jumpsSinceLastLand = 0;

    [Header("Camera")]
    public Transform cam;

    void Start()
    {
        // Use GetComponent to get the CharacterController component
        controller = GetComponent<UnityEngine.CharacterController>();
    }

    void Update()
    {
        Vector3 camForward = cam.forward;
        camForward.y = 0;
        camForward.Normalize();
        Vector3 camRight = cam.right;
        camRight.y = 0;
        camRight.Normalize();

        velocity.z = Input.GetAxis("Vertical") * walkSpeed;
        velocity.x = Input.GetAxis("Horizontal") * strafeSpeed;

        Vector3 movement = (velocity.z * camForward + velocity.x * camRight).normalized;
        velocity = movement * Mathf.Max(velocity.magnitude, 1);

        if (Input.GetKey(sprintKey)) { Sprint(); }

        // Apply manual gravity
        velocity.y += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded && velocity.y < 0) { Land(); }

        if (Input.GetButtonDown("Jump"))
        {
            if (controller.isGrounded)
            {
                Jump();
            }
            else if (jumpsSinceLastLand < maxJumps)
            {
                Jump();
            }
        }

        controller.Move(velocity * Time.deltaTime);
    }

    private void Sprint()
    {
        velocity.z *= sprintFactor;
        velocity.x *= sprintFactor;
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y);
        jumpsSinceLastLand++;
    }

    private void Land()
    {
        velocity.y = 0;
        jumpsSinceLastLand = 0;
    }
}
