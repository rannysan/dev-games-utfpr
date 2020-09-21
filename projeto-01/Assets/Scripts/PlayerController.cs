using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRgb;
    private Animator playerAnim;

    public Transform groundCheck;
    public bool isGround = false;

    public float speed;

    public float touchRun = 0.0f;

    public bool facingRight = true;

    public bool jump = false;
    public float jumpForce;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRgb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        playerAnim.SetBool("IsGrounded", isGround);

        touchRun = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
            jump = true;

        SetMoves();
    }

    void MovePLayer(float moveH)
    {
        playerRgb.velocity = new Vector2(moveH * speed, playerRgb.velocity.y);

        if (moveH < 0 && facingRight || moveH > 0 && !facingRight)
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;

        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void FixedUpdate()
    {
        MovePLayer(touchRun);

        if (jump)
            JumpPlayer();
    }

    void JumpPlayer()
    {
        if (isGround)
        {
            playerRgb.AddForce(new Vector2(0f, jumpForce));
            isGround = false;
        }

        jump = false;
    }

    void SetMoves()
    {
        playerAnim.SetBool("Run", playerRgb.velocity.x != 0);
        playerAnim.SetBool("Jump", !isGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.collider.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
