using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinDiss : MonoBehaviour
{
    private bool collided = false;

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            collided = true;
        }
    }

    void Update()
    {
        if (collided)
        {
            // Wait for 3 seconds before destroying the game object
            Destroy(gameObject, 3f);
        }
    }
}





