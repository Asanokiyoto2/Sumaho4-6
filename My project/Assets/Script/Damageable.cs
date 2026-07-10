using UnityEngine;

[RequireComponent(typeof(Health))]
public class Damageable : MonoBehaviour
{
    private Health health;

    void Awake()
    {
        health = GetComponent<Health>();
    }

    public void TakeDamage(int damage)
    {
        PlayerGuard guard = GetComponent<PlayerGuard>();

        if (guard != null && guard.IsGuarding)
        {
            damage /= 2;
        }

        health.Damage(damage);
    }
}
