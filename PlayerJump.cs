using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;           // how high the player jumps
    public LayerMask groundLayer;          // what is considered ground
    public Transform groundCheck;          // position to check if on ground
    public float groundCheckRadius = 0.2f; // size of the ground check circle

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // check if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // jump when on ground and screen is tapped (for mobile)
        if (isGrounded && IsScreenTapped())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // Check for a screen tap on mobile or left mouse click in Editor
    private bool IsScreenTapped()
    {
        // Touch input (mobile)
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            return true;

        // Mouse click (for testing in editor)
        if (Application.isEditor && Input.GetMouseButtonDown(0))
            return true;

        return false;
    }
}
