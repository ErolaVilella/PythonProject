using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //public string DragName;
    public int targetId;
    public Image thisImage;
    public Vector3 startPosition;
    //private string drop;

    public void OnBeginDrag(PointerEventData eventData)
    {
        thisImage.raycastTarget = false;
        startPosition = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPosition;
        thisImage.raycastTarget = true;
    }
}
