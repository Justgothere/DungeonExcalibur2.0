using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public AudioSource audioPlayer;
    Animator animator;

    Vector2 lookDirection = new Vector2(1, 0);
    private Vector2 moveDirection;
    public Rigidbody2D rb;
    bool isGrounded = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get input values for horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector2 movement = new(horizontalInput, verticalInput);


        //added this to try and animate
        if (!Mathf.Approximately(movement.x, 0.0f) || !Mathf.Approximately(movement.y, 0.0f))
        {
            lookDirection.Set(movement.x, movement.y);
            //lookDirection.Normalize();
        }
        animator.SetFloat("Move X", lookDirection.x);
        animator.SetFloat("Move Y", lookDirection.y);
        // animator.SetFloat("Speed", movement.magnitude);
        


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