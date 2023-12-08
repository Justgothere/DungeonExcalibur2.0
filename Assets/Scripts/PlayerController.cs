using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

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




    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Apply gravity
        Vector2 gravityForce = new Vector2(0, -9.8f) * gravityScale; // Adjust -9.8f based on your gravity needs
        GetComponent<Rigidbody2D>().AddForce(gravityForce);

        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;

        if (moveDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            GetComponent<Rigidbody2D>().rotation = angle;
        }

        Vector2 position = GetComponent<Rigidbody2D>().position;
        position.x += speed * horizontal * Time.fixedDeltaTime;
        //position.y += speed * vertical * Time.fixedDeltaTime;

        GetComponent<Rigidbody2D>().MovePosition(position);
    }
}

