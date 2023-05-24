using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class SceneController : MonoBehaviour
{
    [Header("Arrays")]
    public Drop[] slotsArray;
    public Drag[] dragArray;
    [SerializeField] TMP_Text fillError;
    private bool check;
    public Drag drag;
    public Vector3 Pos;
    public Transform Item;

    [HideInInspector] public int gameScore;

    private void Start()
    {
        fillError.enabled = false;
        //Pos = drag.GetComponent<Drag>().OGPosition;
        gameScore = 0;
    }

    public void fill()
    {
        check = true;

        for (int i = 0; i < slotsArray.Length; i++)
        {
            if (slotsArray[i].filled.Equals(false))
            {
                fillError.text = "¡Hay espacios vacios!";
                fillError.enabled = true;
                check = false;
                slotsArray[i].status = 0;
                return;
            }

        }
        if (check)
        {
            fillError.enabled = false;
            Verify();
        }


    }

    public void Verify()
    {
        foreach (Drag drag in dragArray)
        {
            Drop targetDrop = slotsArray.FirstOrDefault(drop => drop.Id == drag.filledId);
            if (targetDrop == null) continue;

            if (drag.targetId == drag.filledId)
            {
                drag.isDraggable = false;
                targetDrop.GetComponent<Image>().color = Color.green;
            }
            else
            {
                drag.transform.position = drag.OGPosition;
                targetDrop.GetComponent<Image>().color = Color.red;
            }
        }
        AreAllElementsEqual(slotsArray, 2);
    }

    bool AreAllElementsEqual<T>(T[] array, int compareValue)
    {
        if (array == null || array.Length == 0)
            return true;

        for (int i = 0; i < array.Length; i++)
        {
            if (!array[i].Equals(compareValue))
            {
                return false;
            }
        }

        return true;
    }


}
