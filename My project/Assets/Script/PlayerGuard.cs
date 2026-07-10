using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGuard : MonoBehaviour
{
    private PlayerController player;

    public bool IsGuarding { get; private set; }

    void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Mouse.current == null)
            return;

        if (Mouse.current.rightButton.isPressed)
        {
            IsGuarding = true;

            if (player.GetState() != PlayerState.Attack &&
                player.GetState() != PlayerState.Dodge)
            {
                player.SetState(PlayerState.Guard);
            }
        }
        else
        {
            IsGuarding = false;

            if (player.GetState() == PlayerState.Guard)
            {
                player.SetState(PlayerState.Idle);
            }
        }
    }
}
