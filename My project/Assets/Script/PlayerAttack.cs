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

        // プレイヤーのAnimator取得
        Animator animator = GetComponentInChildren<Animator>();

        // 攻撃アニメーション開始
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
        AudioManager.Instance.PlayAttack();

        // 少し待って剣を振るタイミングで当たり判定ON
        yield return new WaitForSeconds(0.15f);

        weapon.EnableHitbox();

        // 当たり判定を少しだけ有効
        yield return new WaitForSeconds(0.15f);

        weapon.DisableHitbox();

        // アニメーション終了待ち
        yield return new WaitForSeconds(0.15f);

        player.SetState(PlayerState.Idle);

        attacking = false;
    }
}
