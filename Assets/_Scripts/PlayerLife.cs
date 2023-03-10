using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float respawnTimer = 1.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Death")) {
            other.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("death");
            Die();
        } else if (other.gameObject.CompareTag("Exit"))
        {
            other.gameObject.GetComponent<AudioSource>().Play();
            Debug.Log("should exit");
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
    }

    void Die() {
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<SpriteRenderer>().enabled = false;
        foreach(Transform child in this.transform) {
            GameObject obj = child.gameObject;
            if (obj.GetComponent<SpriteRenderer>() != null)
            {
                obj.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        StartCoroutine(RestartLevel());
    }

    IEnumerator RestartLevel() {
        Scene currentLevel = SceneManager.GetActiveScene();
        yield return new WaitForSeconds(respawnTimer);
        SceneManager.LoadScene(currentLevel.name);
    }

    
}
