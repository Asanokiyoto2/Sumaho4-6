using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerParry : MonoBehaviour
{
    public float parryTime = 0.2f;

    public bool IsParrying { get; private set; }

    void Update()
    {
        if (Mouse.current == null)
            return;

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            StartCoroutine(ParryRoutine());
        }
    }

    IEnumerator ParryRoutine()
    {
        IsParrying = true;

        yield return new WaitForSeconds(parryTime);

        IsParrying = false;
    }
}
