using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IPointerDownHandler ,IDragHandler,  IBeginDragHandler , IEndDragHandler
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData) //it tells unity u started draggin
    {
        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData) //It tells unit u are dragging
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData) //it tells unity u ended dragging
    {
        Debug.Log("OnEndDrag");
    }

    public void OnPointerDown(PointerEventData eventData) // it tells unity u can drag
    {
        Debug.Log("OnPointerDown");
    }
}

