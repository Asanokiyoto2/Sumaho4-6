using UnityEngine;
using UnityEngine.EventSystems;

public class MobileDodgeButton : MonoBehaviour, IPointerDownHandler
{
    public enum DodgeType
    {
        Left,
        Right
    }

    public DodgeType dodgeType;

    public static bool LeftPressed;
    public static bool RightPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (dodgeType == DodgeType.Left)
        {
            LeftPressed = true;
        }
        else
        {
            RightPressed = true;
        }
    }

    void LateUpdate()
    {
        LeftPressed = false;
        RightPressed = false;
    }
}
