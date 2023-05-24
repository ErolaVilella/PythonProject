using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using UnityEngine.UI;
using TMPro;

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
        print("check");
        check = true;

        for (int i = 0; i < slotsArray.Length; i++)
        {
 
            if (slotsArray[i].filled.Equals(false))
            {
                fillError.text = "Hi ha espais buits";
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

        for (int i = 0; i< slotsArray.Length; i++)
        {
            Pos = dragArray[i].GetComponent<Drag>().OGPosition;

            if (slotsArray[i].status.Equals(2))
            {
                slotsArray[i].GetComponent<Image>().color = Color.green;
                dragArray[i].GetComponent<Drag>().isDraggable = false;
            }

            else if (slotsArray[i].status.Equals(1)) 
            {
                slotsArray[i].GetComponent<Image>().color = Color.red;
                gameScore++;
            }

            else
            {
                slotsArray[i].GetComponent<Image>().color = Color.blue;
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
