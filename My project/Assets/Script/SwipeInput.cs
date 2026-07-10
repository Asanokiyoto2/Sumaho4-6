using UnityEngine;
using UnityEngine.InputSystem;

public class SwipeInput : MonoBehaviour
{
    public float swipeDistance = 80f;

    private PlayerAttack playerAttack;

    private Vector2 startPos;
    private bool touching;

    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE

        // PC‚Å‚Í¶ƒNƒŠƒbƒN
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame)
        {
            playerAttack.Attack();
        }

#endif

#if UNITY_ANDROID || UNITY_IOS

        if (Touchscreen.current == null)
            return;

        var touch = Touchscreen.current.primaryTouch;

        if (touch.press.wasPressedThisFrame)
        {
            startPos = touch.position.ReadValue();
            touching = true;
        }

        if (touch.press.wasReleasedThisFrame && touching)
        {
            Vector2 endPos = touch.position.ReadValue();

            if (Vector2.Distance(startPos, endPos) > swipeDistance)
            {
                playerAttack.Attack();
            }

            touching = false;
        }

#endif
    }
}
