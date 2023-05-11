using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Drag draggable = eventData.pointerDrag.GetComponent<Drag>();
        if (draggable != null)
        {
            draggable.startPosition = transform.position;
        }
    }
   
}
