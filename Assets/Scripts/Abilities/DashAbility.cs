using UnityEngine;

public sealed class DashAbility : PlayerAbility
{
    public float dashSpeed = 16f;
    public float dashDuration = 0.16f;
    public float cooldown = 0.6f;
    public int airDashesAllowed = 1;

    private int airDashesLeft;
    private float nextDashTime;

    void Update()
    {
        if (!IsUnlocked || Player == null) return;

        if (Player.IsGrounded) airDashesLeft = airDashesAllowed;
        if (Input != null && Input.DashPressed) TryActivate();
    }

    public bool TryActivate()
    {
        if (!IsUnlocked || Player == null || Player.IsDashing) return false;
        if (Time.time < nextDashTime) return false;
        if (!Player.IsGrounded && airDashesLeft <= 0) return false;

        float x = Input != null ? Input.MoveX : 0f;
        if (Mathf.Abs(x) < 0.01f) x = Player.FacingDirection;

        if (!Player.IsGrounded) airDashesLeft--;
        nextDashTime = Time.time + cooldown;
        Player.StartDash(new Vector2(Mathf.Sign(x), 0f), dashSpeed, dashDuration);
        return true;
    }

    protected override void OnUnlocked()
    {
        airDashesLeft = airDashesAllowed;
        nextDashTime = 0f;
    }
}
