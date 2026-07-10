using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackRange = 2f;
    public float attackCooldown = 1.2f;

    public Transform target;

    private bool canAttack = true;

    void Update()
    {
        if (target == null)
            return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= attackRange && canAttack)
        {
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        canAttack = false;

        Damageable damageable = target.GetComponent<Damageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damage);
        }

        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
    }
}
