using UnityEngine;

public sealed class DoubleJumpAbility : PlayerAbility, IAirJumpProvider
{
    public int airJumpsAllowed = 1;

    private int airJumpsLeft;

    void Update()
    {
        if (!IsUnlocked || Player == null) return;
        if (Player.IsGrounded) airJumpsLeft = airJumpsAllowed;
    }

    public bool CanAirJump()
    {
        return IsUnlocked && Player != null && !Player.IsGrounded && airJumpsLeft > 0;
    }

    public void ConsumeAirJump()
    {
        airJumpsLeft--;
    }

    protected override void OnUnlocked()
    {
        airJumpsLeft = airJumpsAllowed;
    }
}
