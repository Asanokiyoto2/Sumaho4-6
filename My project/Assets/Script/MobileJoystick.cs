using UnityEngine;
using UnityEngine.EventSystems;

public class MobileJoystick : MonoBehaviour,
IDragHandler,
IPointerDownHandler,
IPointerUpHandler
{
    [Header("つまみ")]
    public RectTransform handle;

    [Header("外側")]
    public RectTransform background;

    // プレイヤーが取得する移動方向
    public Vector2 InputDirection { get; private set; }

    float radius;

    void Start()
    {
        radius = background.sizeDelta.x / 2f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            background,
            eventData.position,
            eventData.pressEventCamera,
            out pos);

        pos = Vector2.ClampMagnitude(pos, radius);

        handle.anchoredPosition = pos;

        InputDirection = pos / radius;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        handle.anchoredPosition = Vector2.zero;

        InputDirection = Vector2.zero;
    }
}
