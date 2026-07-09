using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public WeaponCollider weapon;
    public float attackTime = 0.35f;

    private bool attacking;

    void Update()
    {
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (attacking)
            return;

        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        attacking = true;

        weapon.EnableHitbox();

        yield return new WaitForSeconds(attackTime);

        weapon.DisableHitbox();

        attacking = false;
    }
}
