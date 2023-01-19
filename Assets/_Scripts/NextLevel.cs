using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    private AudioSource finishSound;

    private void Start()
    {
        // finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player") {
            // finishSound.Play();
            completeLevel();
        }
    }

    private void completeLevel() {

    }
}
