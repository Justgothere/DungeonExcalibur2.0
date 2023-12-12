using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public AudioSource audioPlayer;

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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "CollisionTag")
        {
            audioPlayer.Play();
        }
    }
}