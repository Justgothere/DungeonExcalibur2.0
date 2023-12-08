using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public float gravityScale = 1.0f;
    public int maxHealth = 10;

    public int health { get { return currentHealth; } }

    int currentHealth;

    public float timeInvincible = 1.0f;
    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2D;
    float horizontal;
    float vertical;

    Animator animator;

    Vector2 lookDirection = new Vector2(1, 0);


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = gravityScale;

    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }
    void HandleMovementInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical).normalized;

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection = move;
        }
    }



    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Apply gravity
        Vector2 gravityForce = new Vector2(0, -9.8f) * gravityScale; // Adjust -9.8f based on your gravity needs
        rigidbody2D.AddForce(gravityForce);

        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;

        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            rigidbody2D.rotation = angle;
        }

        Vector2 position = rigidbody2D.position;
        position.x += speed * horizontal * Time.fixedDeltaTime;
        //position.y += speed * vertical * Time.fixedDeltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2D.MovePosition(position);
    }
}