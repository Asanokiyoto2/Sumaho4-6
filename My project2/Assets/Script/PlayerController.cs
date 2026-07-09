using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private CharacterController controller;

    private PlayerState state;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
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
        }
        else
        {
            state = PlayerState.Idle;
        }
    }
}
