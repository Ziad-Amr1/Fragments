using UnityEngine;

public sealed class FragmentCollectible : MonoBehaviour
{
    public AbilityId unlocks;
    public bool destroyOnCollect = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        AbilityManager abilities = other.GetComponent<AbilityManager>();
        if (abilities == null) abilities = other.GetComponentInChildren<AbilityManager>();
        if (abilities == null) return;

        if (abilities.Unlock(unlocks) && destroyOnCollect)
        {
            Destroy(gameObject);
        }
    }
}
