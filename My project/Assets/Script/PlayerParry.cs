using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerParry : MonoBehaviour
{
    public float parryTime = 0.2f;

    public bool IsParrying { get; private set; }

    private bool parryRunning;

    void Update()
    {
        if (Mouse.current == null)
            return;

        if (Mouse.current.rightButton.wasPressedThisFrame && !parryRunning)
        {
            StartCoroutine(ParryRoutine());
        }
    }

    IEnumerator ParryRoutine()
    {
        parryRunning = true;
        IsParrying = true;

        yield return new WaitForSeconds(parryTime);

        IsParrying = false;
        parryRunning = false;
    }
}
