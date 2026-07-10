using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerDodge : MonoBehaviour
{
    public float dodgeDistance = 3f;
    public float dodgeTime = 0.2f;
    private CharacterController controller;
    private PlayerController player;
    private bool dodging;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Mouse.current == null)
            return;

        if (!dodging)
        {
            if (Keyboard.current.qKey.wasPressedThisFrame)
            {
                StartCoroutine(DodgeRoutine(Vector3.left));
            }
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                StartCoroutine(DodgeRoutine(Vector3.right));
            }
        }
    }
    IEnumerator DodgeRoutine(Vector3 direction)
    {
        dodging = true;
        player.SetState(PlayerState.Dodge);
        float timer = 0f;

        while (timer < dodgeTime)
        {
            controller.Move(direction * (dodgeDistance / dodgeTime) * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        player.SetState(PlayerState.Idle);
        dodging = false;
    }
}
