using UnityEngine;
using UnityEngine.SceneManagement;

public class Toforest : MonoBehaviour {

    public string Forest;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(Forest);
        }
    }

}

