using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    private bool isGrounded;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // Get input values for horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement vector
        Vector2 movement = new Vector2(horizontalInput, 0f);

        // Normalize the vector to prevent faster diagonal movement
        movement = movement.normalized;

        // Move the character
        MoveCharacter(movement);

        // Check if the player is grounded
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f, groundLayer);

        // Jump when the space key is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void MoveCharacter(Vector2 direction)
    {
        // Move the character using Rigidbody2D
        transform.Translate(direction * speed * Time.deltaTime);
    }
    void Jump()
    {
        // Add an upward force to the rigidbody to make the character jump
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
