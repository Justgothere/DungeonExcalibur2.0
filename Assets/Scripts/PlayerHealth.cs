using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public GameManagerScript gameManager;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        // Ensure health doesn't go below 0 or exceed maxHealth
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Check if the player is dead
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
            Die();
        }
    }

    void Die()
    {
        // Add any death-related logic here, such as respawning or game over screen
        Debug.Log("Player has died!");
        Destroy(gameObject);
    }
}
