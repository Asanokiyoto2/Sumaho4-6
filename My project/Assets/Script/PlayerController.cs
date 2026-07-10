using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed = 5f;

    private Health health;
    private CharacterController controller;
    private PlayerAttack playerAttack;

    private PlayerState state;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        health = GetComponent<Health>();
        animator = GetComponent<Animator>();

        playerAttack = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if (health.IsDead)
        {
            state = PlayerState.Dead;
            return;
        }

        if (state == PlayerState.Attack || state == PlayerState.Dodge)
        {
            return;
        }

        Move();

        AttackInput();
    }

    void Move()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.wKey.isPressed)
                input.y += 1;

            if (Keyboard.current.sKey.isPressed)
                input.y -= 1;

            if (Keyboard.current.aKey.isPressed)
                input.x -= 1;

            if (Keyboard.current.dKey.isPressed)
                input.x += 1;
        }

        Vector3 move = new Vector3(input.x, 0, input.y);

        controller.Move(move.normalized * moveSpeed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            transform.forward = move;
            state = PlayerState.Move;

            //animator.SetBool("Move", true);
        }
        else
        {
            state = PlayerState.Idle;

            //animator.SetBool("Move", false);
        }
    }
    public void SetState(PlayerState newState)
    {
        state = newState;
    }
    void AttackInput()
    {
        if (Mouse.current == null)
            return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            playerAttack.Attack();
        }
    }
    public PlayerState GetState()
    {
        return state;
    }
}
