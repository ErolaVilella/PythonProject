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

    private void Start()
    {
        OGPosition = startPosition;
    }

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Drop>().filled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Drop>().status = 0;
        collision.gameObject.GetComponent<Drop>().filled = false;
    }
}
