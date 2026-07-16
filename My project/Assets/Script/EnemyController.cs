using UnityEngine;
using System.Collections;

// CharacterControllerが必須
[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour
{

    private Animator animator;
    [Header("攻撃設定")]

    // 攻撃前の予備動作時間（プレイヤーがパリィしやすくする）
    public float attackWindup = 0.6f;

    // 攻撃後の硬直時間
    public float attackRecover = 0.8f;

    // 現在攻撃中かどうか
    private bool attacking;


    [Header("移動設定")]

    // プレイヤー
    public Transform target;

    // 敵の移動速度
    public float moveSpeed = 2f;

    // この距離まで近づいたら攻撃する
    public float attackDistance = 2f;


    // CharacterController
    private CharacterController controller;

    // 現在の敵の状態
    private EnemyState state = EnemyState.Idle;

    // スタンしているか
    private bool stunned;


    void Awake()
    {
        controller = GetComponent<CharacterController>();

        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // HP取得
        Health health = GetComponent<Health>();

        // 死亡していたら何もしない
        if (health.IsDead)
        {
            state = EnemyState.Dead;
            animator.SetBool("Move", false);
            return;
        }

        // スタン中は動かない
        if (stunned)
            return;

        // プレイヤーがいなければ何もしない
        if (target == null)
            return;

        // プレイヤーとの距離
        float distance = Vector3.Distance(transform.position, target.position);

        // 遠いなら追いかける
        if (distance > attackDistance)
        {
            Chase();
        }
        // 近いなら攻撃
        else
        {
            // 一旦停止
            controller.Move(Vector3.zero);

            animator.SetBool("Move", false);

            // 攻撃中でなければ攻撃開始
            if (!attacking)
            {
                StartCoroutine(AttackRoutine());
            }
        }
    }


    /// <summary>
    /// プレイヤーを追いかける
    /// </summary>
    void Chase()
    {
        // 状態変更
        state = EnemyState.Chase;
        animator.SetBool("Move", true);

        // プレイヤー方向
        Vector3 dir = target.position - transform.position;

        // 高さは無視
        dir.y = 0;

        // プレイヤーの方を向く
        transform.forward = dir.normalized;

        // 前進
        controller.Move(dir.normalized * moveSpeed * Time.deltaTime);
    }


    /// <summary>
    /// パリィ成功時に呼ばれる
    /// </summary>
    public void Stun(float time)
    {
        if (!stunned)
        {
            StartCoroutine(StunRoutine(time));
        }
    }


    /// <summary>
    /// スタン処理
    /// </summary>
    IEnumerator StunRoutine(float time)
    {
        // スタン開始
        stunned = true;

        state = EnemyState.Hit;
        animator.SetTrigger("Hit");

        // 指定時間待つ
        yield return new WaitForSeconds(time);

        // スタン終了
        stunned = false;

        state = EnemyState.Idle;
        animator.SetBool("Move", false);
    }


    /// <summary>
    /// 攻撃処理
    /// </summary>
    IEnumerator AttackRoutine()
    {
        // 攻撃開始
        attacking = true;

        state = EnemyState.Attack;
        animator.SetTrigger("Attack");
        animator.SetBool("Move", false);

        // 攻撃予告
        yield return new WaitForSeconds(attackWindup);

        // EnemyAttackを取得
        EnemyAttack attack = GetComponent<EnemyAttack>();

        // 実際の攻撃
        if (attack != null)
        {
            attack.Attack();
        }

        // 攻撃後の硬直
        yield return new WaitForSeconds(attackRecover);

        // 待機状態へ
        state = EnemyState.Idle;

        // 攻撃終了
        attacking = false;
    }
}