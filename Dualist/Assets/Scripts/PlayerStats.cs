using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int healthLevel = 10;
    public int maxHealth;
    public int currentHealth;

    public int spiritLevel = 10;
    public int maxSpirit;
    public int currentSpirit;

    public HealthBar healthBar;
    public SpiritBar spiritBar;

    void Start()
    {
        maxHealth = SexMaxHealthFromHealthLevel();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        maxSpirit = SexMaxSpiritFromSpiritLevel();
        currentSpirit = maxSpirit;
        spiritBar.SetMaxSpirit(maxSpirit);
    }

    private int SexMaxHealthFromHealthLevel()
    {
        maxHealth = healthLevel * 10;
        return maxHealth;
    }

    private int SexMaxSpiritFromSpiritLevel()
    {
        maxSpirit = spiritLevel * 10;
        return maxSpirit;
    }

    public void TakeHealthDamage(int damage)
    {
        currentHealth = currentHealth - damage;

        healthBar.SetCurrentHealth(currentHealth);
    }

    public void TakeSpiritDamage(int damage)
    {
        currentSpirit = currentSpirit - damage;

        spiritBar.SetCurrentSpirit(currentSpirit);
    }

    public void Update()
    {
        if (currentHealth >= 100f)
        {
            currentHealth = 100;
        }

        if (currentSpirit >= 100f)
        {
            currentSpirit = 100;
        }

        if (currentHealth <= 0f)
        {
            currentHealth = 0;
        }

        if (currentSpirit <= 0f)
        {
            currentSpirit = 0;
        }
    }
}
