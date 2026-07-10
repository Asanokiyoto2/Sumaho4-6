using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 2f;
    public float attackDistance = 2f;

    private CharacterController controller;
    private EnemyState state = EnemyState.Idle;
    private bool stunned;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Health health = GetComponent<Health>();

        if (health.IsDead)
        {
            state = EnemyState.Dead;
            return;
        }
        if (stunned)
            return;
        if (target == null)
            return;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > attackDistance)
        {
            Chase();
        }
        else
        {
            state = EnemyState.Attack;
            controller.Move(Vector3.zero);
        }
    }

    void Chase()
    {
        state = EnemyState.Chase;

        Vector3 dir = target.position - transform.position;
        dir.y = 0;

        transform.forward = dir.normalized;

        controller.Move(dir.normalized * moveSpeed * Time.deltaTime);
    }
    public void Stun(float time)
    {
        if (!stunned)
        {
            StartCoroutine(StunRoutine(time));
        }
    }

    System.Collections.IEnumerator StunRoutine(float time)
    {
        stunned = true;

        state = EnemyState.Hit;

        yield return new WaitForSeconds(time);

        stunned = false;

        state = EnemyState.Idle;
    }
}