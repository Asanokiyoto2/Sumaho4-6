using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public WeaponCollider weapon;
    public float attackTime = 0.35f;

    private PlayerController player;
    private bool attacking;

    void Start()
    {
        player = GetComponent<PlayerController>();

        weapon.DisableHitbox();
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

        player.SetState(PlayerState.Attack);

        weapon.EnableHitbox();

        yield return new WaitForSeconds(attackTime);

        weapon.DisableHitbox();

        player.SetState(PlayerState.Idle);

        attacking = false;
    }
}
