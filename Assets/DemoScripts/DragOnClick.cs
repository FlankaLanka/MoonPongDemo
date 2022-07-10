using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragOnClick : MonoBehaviour, IDragHandler
{
    private RectTransform dragRectTransform;
    [SerializeField]
    private Canvas canvas;

    private void Start()
    {
        dragRectTransform = this.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
}
