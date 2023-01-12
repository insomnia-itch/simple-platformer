using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private PlatformEffector2D effector;
    float waitTime;
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > -1)
        {
            waitTime = 0.5f;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            effector.rotationalOffset = 180f;
            waitTime = 0.5f;
        }   else
        {
            waitTime -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            effector.rotationalOffset = 0;
        }
    }
}
