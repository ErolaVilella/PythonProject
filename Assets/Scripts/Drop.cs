using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drop : MonoBehaviour, IDropHandler
{

    //public string nomSlot;
    [HideInInspector] public int status;
    [HideInInspector] public bool filled;
    public int Id;

    //public int[] i = new int[10];

    private void Start()
    {
        status = 0;
        filled = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Drag draggable = eventData.pointerDrag.GetComponent<Drag>();
        if (draggable != null)
        {
            draggable.startPosition = transform.position;
        }
        if (draggable.targetId == Id)
        {
            status = 2;

        }
        else
        {
            status = 1;
        }
        draggable.filledId = Id;
    }

}
