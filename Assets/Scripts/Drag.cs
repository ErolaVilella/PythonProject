using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
  
    public int targetId;
    public Image thisImage;
    public Vector3 startPosition;
    public Vector3 OGPosition;
    public bool isDraggable;

    private void Start()
    {
        OGPosition = transform.position;
        //print(OGPosition);
        isDraggable = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isDraggable) {
        thisImage.raycastTarget = false;
        startPosition = transform.position;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDraggable)
        {
            transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDraggable)
        {
            transform.position = startPosition;
            thisImage.raycastTarget = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Drop>().filled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Drop>().filled = false;
    }

    private void Update()
    {
        
    }
}
