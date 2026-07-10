using UnityEngine;
using UnityEngine.EventSystems;

public class MobileGuardButton : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler
{
    // 他のスクリプトから参照できる
    public static bool IsPressed;
    public static bool WasPressedThisFrame;
    void Update()
    {
        WasPressedThisFrame = false;
    }

    // ボタンを押した
    public void OnPointerDown(PointerEventData eventData)
    {
        IsPressed = true;
        WasPressedThisFrame = true;
    }

    // ボタンを離した
    public void OnPointerUp(PointerEventData eventData)
    {
        IsPressed = false;
    }
}
