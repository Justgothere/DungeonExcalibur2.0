using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public int maxHealth = 10;
    int currentHealth;

    //This will be used in order to make player invincible after being hurt
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    
    /// Player attack things
    public float delay = 0.4f;
    private bool attackBlocked;


    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        // Get input values for horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize the vector to prevent faster diagonal movement
        movement = movement.normalized;

        // Move the character
        MoveCharacter(movement);
    }



    void MoveCharacter(Vector2 direction)
    {
        // Move the character using Rigidbody2D
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }




}
