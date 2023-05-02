using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinDiss : MonoBehaviour
{
    private bool collided = false;
    public GameObject Winds;

private void Start()
    {
       Winds.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collided = true;
            Destroy(gameObject, 2f);
        }
    }

    void Update()
    {
        if (collided)
        {
            Winds.gameObject.SetActive(true);
        }
    }
}





