using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{

    //public string nomSlot;
    [HideInInspector] public int status;
    public int Id;
    //public int[] i = new int[10];

    private void Start()
    {
        status = 0;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Drag draggable = eventData.pointerDrag.GetComponent<Drag>();
        if (draggable != null)
        {
            draggable.startPosition = transform.position;
        }

        print(draggable.targetId);
        print(Id);

        if (draggable.targetId == Id)
        {
            status = 2;

        }
        else
        {
            status = 1;
        }
        
    }
    
   
}
