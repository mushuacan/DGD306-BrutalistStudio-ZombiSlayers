// ChatGPT taraf�ndan olu�turulmu�tur.
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;  // Karakterin alt�ndaki k���k collider
    public LayerMask groundLayer;  // Zeminin hangi layer'de oldu�unu belirler

    public Animator animator;

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpPhase;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Karakteri sa�a-sola hareket ettir
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        animator.SetFloat("Horizontal Speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("Vertical Speed", rb.velocity.y);

        // Zeminde olup olmad���n� kontrol et
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        animator.SetBool("IsGrounded", isGrounded);

        if (isGrounded && Input.GetKey(KeyCode.Space) && (jumpPhase == 0 || jumpPhase == 1))
        {
            jumpPhase = 1;
            animator.SetBool("Jumping", true);
        }
        else if (isGrounded && !Input.GetKey(KeyCode.Space) && jumpPhase == 1)
        {
            jumpPhase = 2;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("Jumping", false);
        }
        else if (!isGrounded && jumpPhase == 2)
        {
            jumpPhase = 3;
        }
        else
        {
            jumpPhase = 0;
        }

        if (rb.velocity.x < 0) // Karakter sola bakacak
        {
            transform.localScale = new Vector3(-1, 1, 1); // X ekseninde negatif yap
        }
        else if (rb.velocity.x > 0) // Karakter sa�a bakacak
        {
            transform.localScale = new Vector3(1, 1, 1); // X ekseninde pozitif yap
        }
    }
}