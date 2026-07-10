using UnityEngine;
using UnityEngine.EventSystems;

public class MobileGuardButton : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler
{
    // 他のスクリプトから参照できる
    public static bool IsPressed;

    // ボタンを押した
    public void OnPointerDown(PointerEventData eventData)
    {
        IsPressed = true;
    }

    // ボタンを離した
    public void OnPointerUp(PointerEventData eventData)
    {
        IsPressed = false;
    }
}
