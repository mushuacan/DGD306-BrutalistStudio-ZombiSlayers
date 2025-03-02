// ChatGPT taraf�ndan olu�turulmu�tur.
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;  // Karakterin alt�ndaki k���k collider
    public LayerMask groundLayer;  // Zeminin hangi layer'de oldu�unu belirler

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Karakteri sa�a-sola hareket ettir
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Zeminde olup olmad���n� kontrol et
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); 

        // Z�plama i�lemi
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}