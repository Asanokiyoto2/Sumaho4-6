using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGuard : MonoBehaviour
{
    private PlayerController player;
    private Animator animator;

    public bool IsGuarding { get; private set; }

    void Awake()
    {
        player = GetComponent<PlayerController>();

        // 子オブジェクトのAnimator取得
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        bool guardInput = false;

        // PC
        if (Mouse.current != null && Mouse.current.rightButton.isPressed)
        {
            guardInput = true;
        }

        // スマホ
        if (MobileGuardButton.IsPressed)
        {
            guardInput = true;
        }

        // ガード開始
        if (guardInput)
        {
            IsGuarding = true;

            if (animator != null)
                animator.SetBool("Guard", true);

            if (player.GetState() != PlayerState.Attack &&
                player.GetState() != PlayerState.Dodge)
            {
                player.SetState(PlayerState.Guard);
            }
        }
        // ガード解除
        else
        {
            IsGuarding = false;

            if (animator != null)
                animator.SetBool("Guard", false);

            if (player.GetState() == PlayerState.Guard)
            {
                player.SetState(PlayerState.Idle);
            }
        }
    }
}
