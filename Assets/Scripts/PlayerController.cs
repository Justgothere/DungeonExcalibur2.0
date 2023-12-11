using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int maxHealth = 100; 
    private int currentHealth;

    void Update()
    {
        // Get input values for horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector2 movement = new(horizontalInput, verticalInput);

        // Normalize the vector to prevent faster diagonal movement
        movement = movement.normalized;

        // Move the character
        MoveCharacter(movement);

    }

    void MoveCharacter(Vector2 direction)
    {
        // Move the character using Rigidbody2D
        transform.Translate(speed * Time.deltaTime * direction);
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;

        // Ensure health doesn't go below 0 or exceed maxHealth
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        // Check if the player is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Add any death-related logic here, such as respawning or game over screen
        Debug.Log("Player has died!");
    }
}