using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BoiHealth : MonoBehaviour
{
    public int maxHealth = 100;
    //public GameObject deathEffect;
    public int currentHealth;
    public HealthBar healthBar;
    public int NumberOfMasks = 0;
    public Animator animator;
    public PauseMenu endGame;

    void Start()
    {
        currentHealth = maxHealth;
        if (SceneManager.GetActiveScene().name == "Game")
        {
            healthBar.SetMaxHealth(maxHealth);
            animator.SetInteger("Health", currentHealth);
        }
    }
    void Update()
    {
        animator.SetInteger("NumberOfMasks", NumberOfMasks);
        animator.SetInteger("Health", currentHealth);
    }
    public void TakeDamage(int damage)
    {
        if (NumberOfMasks > 0)
        {
            NumberOfMasks--;
        }
        else
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                Die();
            }
        }

    }
    public void PickUpMask()
    {
        NumberOfMasks++;
    }

    public void PickupCPills()
    {
        if (currentHealth < maxHealth)
        {
            if (currentHealth == maxHealth - 10)
            {
                currentHealth = currentHealth + 10;
                healthBar.SetHealth(currentHealth);
            }
            else
            {
                currentHealth = currentHealth + 20;
                healthBar.SetHealth(currentHealth);
            }

        }
    }
    public void PickupFirstAid()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }
    public void PickupBluePills()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth = currentHealth + 10;
            healthBar.SetHealth(currentHealth);
        }
    }
    void Die()
    {
        endGame.GameOverScreen();
    }
}
