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
        

        bool parryInput = false;

        // PC
        if (Mouse.current != null &&
            Mouse.current.rightButton.wasPressedThisFrame)
        {
            parryInput = true;
        }

        // ÉXÉ}Éz
        if (MobileGuardButton.WasPressedThisFrame)
        {
            parryInput = true;
        }

        if (parryInput && !parryRunning)
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
