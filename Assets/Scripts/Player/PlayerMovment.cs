using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput), typeof(AbilityManager))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public float coyoteTime = 0.1f;
    public float jumpBufferTime = 0.12f;
    public float jumpCutMultiplier = 0.5f;

    public Rigidbody2D Body { get; private set; }
    public PlayerInput Input { get; private set; }
    public AbilityManager Abilities { get; private set; }
    public bool IsGrounded { get; private set; }
    public bool IsDashing => dashTimeLeft > 0f;
    public float FacingDirection { get; private set; } = 1f;

    private float lastGroundedAt = -100f;
    private float lastJumpPressedAt = -100f;
    private bool wasJumpHeld;
    private Vector2 dashVelocity;
    private float dashTimeLeft;
    private float originalGravity;

    void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
        if (Body == null) Body = gameObject.AddComponent<Rigidbody2D>();

        Input = GetComponent<PlayerInput>();
        if (Input == null) Input = gameObject.AddComponent<PlayerInput>();

        Abilities = GetComponent<AbilityManager>();
        if (Abilities == null) Abilities = gameObject.AddComponent<AbilityManager>();

        originalGravity = Body.gravityScale;
    }

    void Update()
    {
        float moveX = Input.MoveX;
        if (Mathf.Abs(moveX) > 0.01f)
        {
            FacingDirection = Mathf.Sign(moveX);
        }

        if (Input.JumpPressed)
        {
            lastJumpPressedAt = Time.time;
        }

        bool jumpHeld = Input.JumpHeld;
        if (wasJumpHeld && !jumpHeld && Body.linearVelocity.y > 0f && !IsDashing)
        {
            Body.linearVelocity = new Vector2(Body.linearVelocity.x, Body.linearVelocity.y * jumpCutMultiplier);
        }
        wasJumpHeld = jumpHeld;
    }

    void FixedUpdate()
    {
        CheckGround();

        Vector2 velocity = Body.linearVelocity;

        if (dashTimeLeft > 0f)
        {
            velocity = dashVelocity;
            dashTimeLeft -= Time.fixedDeltaTime;
            if (dashTimeLeft <= 0f)
            {
                dashTimeLeft = 0f;
                Body.gravityScale = originalGravity;
            }
        }
        else
        {
            velocity.x = Input.MoveX * speed;
            if (Time.time - lastJumpPressedAt <= jumpBufferTime && TryConsumeJump())
            {
                velocity.y = jumpForce;
                lastJumpPressedAt = -100f;
                lastGroundedAt = -100f;
            }
        }

        Body.linearVelocity = velocity;
    }

    public void StartDash(Vector2 direction, float dashSpeed, float duration)
    {
        if (Body == null || duration <= 0f) return;

        dashVelocity = direction.normalized * dashSpeed;
        dashTimeLeft = duration;
        Body.gravityScale = 0f;
        lastJumpPressedAt = -100f;
    }

    public void ResetState()
    {
        dashTimeLeft = 0f;
        dashVelocity = Vector2.zero;
        lastGroundedAt = -100f;
        lastJumpPressedAt = -100f;
        wasJumpHeld = false;

        if (Body != null)
        {
            Body.linearVelocity = Vector2.zero;
            Body.gravityScale = originalGravity;
        }
    }

    bool TryConsumeJump()
    {
        if (Time.time - lastGroundedAt <= coyoteTime) return true;
        return Abilities != null && Abilities.TryConsumeAirJump();
    }

    void CheckGround()
    {
        if (groundCheck == null)
        {
            IsGrounded = false;
            return;
        }

        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) != null;
        if (IsGrounded)
        {
            lastGroundedAt = Time.time;
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
