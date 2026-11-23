using UnityEngine;

public abstract class PlayerAbility : MonoBehaviour
{
    public AbilityId id;
    public string displayName;
    public bool startUnlocked;

    public bool IsUnlocked { get; private set; }
    protected PlayerMovement Player { get; private set; }
    protected PlayerInput Input => Player != null ? Player.Input : null;

    public virtual void Setup(PlayerMovement player)
    {
        Player = player;
        IsUnlocked = startUnlocked;
        if (IsUnlocked) OnUnlocked();
    }

    public void Unlock()
    {
        if (IsUnlocked) return;
        IsUnlocked = true;
        OnUnlocked();
    }

    public void Lock()
    {
        if (!IsUnlocked) return;
        IsUnlocked = false;
        OnLocked();
    }

    protected virtual void OnUnlocked() { }
    protected virtual void OnLocked() { }
}
