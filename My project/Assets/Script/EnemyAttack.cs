using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackRange = 2f;
    public float attackCooldown = 1.2f;

    public Transform target;

    private bool canAttack = true;

    public void Attack()
    {
        if (!canAttack)
            return;

        canAttack = false;

        PlayerParry parry = target.GetComponent<PlayerParry>();

        if (parry != null && parry.IsParrying)
        {
            GetComponent<EnemyController>().Stun(2f);
        }
        else
        {
            Damageable damageable = target.GetComponent<Damageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(damage);

                if (HitStop.Instance != null)
                    HitStop.Instance.Stop(0.05f);
            }
        }

        Invoke(nameof(ResetAttack), attackCooldown);
    }

    void ResetAttack()
    {
        canAttack = true;
    }
}
