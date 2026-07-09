using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class WeaponCollider : MonoBehaviour
{
    public int damage = 20;

    private Collider weaponCollider;
    private HashSet<Damageable> hitTargets = new HashSet<Damageable>();

    void Awake()
    {
        weaponCollider = GetComponent<Collider>();
        weaponCollider.enabled = false;
    }

    public void EnableHitbox()
    {
        hitTargets.Clear();
        weaponCollider.enabled = true;
    }

    public void DisableHitbox()
    {
        weaponCollider.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Damageable damageable = other.GetComponent<Damageable>();

        if (damageable == null)
            return;

        if (hitTargets.Contains(damageable))
            return;

        hitTargets.Add(damageable);

        damageable.TakeDamage(damage);
    }
}
