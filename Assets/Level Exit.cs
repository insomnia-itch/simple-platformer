using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;

    private void Start()
    {
        // finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && !levelCompleted) {
            // finishSound.Play();
            // CompleteLevel();
            // call method with delay
            Invoke("CompleteLevel", 1.5f);
            levelCompleted = true;
        }
    }

    private void CompleteLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene( currentSceneIndex + 1);
        // TODO add game over screne if out of index
    }
}
