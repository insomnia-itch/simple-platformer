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
            Invoke("CompleteLevel", 0.8f);
            levelCompleted = true;
        }
    }

    private void CompleteLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        int numberOfScenes = SceneManager.sceneCountInBuildSettings;

        //  TOOD probably a better way to do this
        if (currentSceneIndex == numberOfScenes - 1)
        {
         nextSceneIndex = 0;   
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
