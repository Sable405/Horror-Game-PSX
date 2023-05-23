using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class KeyCollection : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(3);
        }
    }
}