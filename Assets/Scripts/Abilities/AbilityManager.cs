using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class AbilityManager : MonoBehaviour
{
    public bool persistUnlocks;
    public string saveKey = "Fragments.Abilities";

    public event Action<AbilityId> AbilityUnlocked;

    private readonly List<PlayerAbility> abilities = new List<PlayerAbility>();

    void Awake()
    {
        PlayerMovement player = GetComponent<PlayerMovement>();
        abilities.AddRange(GetComponentsInChildren<PlayerAbility>(true));

        foreach (PlayerAbility ability in abilities)
        {
            ability.Setup(player);
        }

        Load();
    }

    public bool IsUnlocked(AbilityId id)
    {
        if (id == AbilityId.None) return false;

        foreach (PlayerAbility ability in abilities)
        {
            if (ability.id == id) return ability.IsUnlocked;
        }
        return false;
    }

    public bool Unlock(AbilityId id)
    {
        if (id == AbilityId.None || IsUnlocked(id)) return false;

        foreach (PlayerAbility ability in abilities)
        {
            if (ability.id != id) continue;

            ability.Unlock();
            AbilityUnlocked?.Invoke(id);
            Save();
            return true;
        }
        return false;
    }

    public bool TryConsumeAirJump()
    {
        foreach (PlayerAbility ability in abilities)
        {
            if (!ability.IsUnlocked) continue;
            if (!(ability is IAirJumpProvider provider)) continue;
            if (!provider.CanAirJump()) continue;

            provider.ConsumeAirJump();
            return true;
        }
        return false;
    }

    public void ResetProgress()
    {
        foreach (PlayerAbility ability in abilities) ability.Lock();
        PlayerPrefs.DeleteKey(saveKey);
    }

    void Save()
    {
        if (!persistUnlocks) return;

        List<string> ids = new List<string>();
        foreach (PlayerAbility ability in abilities)
        {
            if (ability.IsUnlocked) ids.Add(ability.id.ToString());
        }

        PlayerPrefs.SetString(saveKey, string.Join(",", ids));
        PlayerPrefs.Save();
    }

    void Load()
    {
        if (!persistUnlocks) return;

        string saved = PlayerPrefs.GetString(saveKey, string.Empty);
        if (string.IsNullOrEmpty(saved)) return;

        string[] parts = saved.Split(',');
        foreach (string part in parts)
        {
            if (Enum.TryParse(part, out AbilityId id)) Unlock(id);
        }
    }
}
