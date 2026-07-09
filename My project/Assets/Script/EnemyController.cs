using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 2f;
    public float attackDistance = 2f;

    private CharacterController controller;
    private EnemyState state = EnemyState.Idle;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
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
}