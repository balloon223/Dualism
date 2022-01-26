using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject key1;
    public GameObject door1;

    public bool isCollidingWithKey1;
    public bool isCollidingWithDoor1;

    public bool hasKey1;

    public bool isColliding;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "key1")
        {
            isCollidingWithKey1 = true;
        }

        if (other.gameObject.tag == "door1")
        {
            isCollidingWithDoor1 = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "key1")
        {
            isCollidingWithKey1 = false;
        }

        if (other.gameObject.tag == "door1")
        {
            isCollidingWithDoor1 = false;
        }
    }


    private void Update()
    {
        if (isCollidingWithKey1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                hasKey1 = true;
                Destroy(key1);
                audioSource.Play();
            }
        }

        if (isCollidingWithDoor1 && hasKey1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(door1);
                audioSource.Play();
            }
        }
    }
}
