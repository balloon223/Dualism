using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpirit : MonoBehaviour
{
    public bool isColliding;
    public int damage = -25;
    PlayerStats playerStats;
    AudioSource audioSource;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
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
                playerStats.TakeSpiritDamage(damage);
                audioSource.Play();
            }
        }
    }
}
