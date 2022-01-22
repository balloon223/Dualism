using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHealth : MonoBehaviour
{
    public bool isColliding;
    public int damage = 25;
    PlayerStats playerStats;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isColliding = true;
    }

    private void Update()
    {
        if (isColliding)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                playerStats.TakeHealthDamage(damage);
            }        
        }
    }
}
