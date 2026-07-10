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
        bool guardInput = false;

        // PC
        if (Mouse.current != null &&
            Mouse.current.rightButton.isPressed)
        {
            guardInput = true;
        }

        // ÉXÉ}Éz
        if (MobileGuardButton.IsPressed)
        {
            guardInput = true;
        }

        if (guardInput)
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
