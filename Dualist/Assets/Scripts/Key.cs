using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject door;
    public bool isColliding;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isColliding = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isColliding = false;
    }

    private void Update()
    {
        if (isColliding)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(door);
                audioSource.Play();
            }
        }
    }
}
