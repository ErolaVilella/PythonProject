using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using UnityEngine.UI;
using TMPro;

public class SceneController : MonoBehaviour
{
    public Drop[] potetos;
    public Drag[] dragArray;
    [SerializeField] TMP_Text fillError;
    private bool check;
    public Drag drag;
    public Vector3 Pos;
    public Transform Item;

    private void Start()
    {
        fillError.enabled = false;
        //Pos = drag.GetComponent<Drag>().OGPosition;
    }

    public void fill()
    {
        check = true;

        for (int i = 0; i < potetos.Length; i++)
        {
 
            if (potetos[i].filled.Equals(false))
            {
                fillError.text = "Hi ha espais buits";
                fillError.enabled = true;
                check = false;
                potetos[i].status = 0;
                return;
            }
            
        }
        if (check)
        {
            print("entra al check true");
            fillError.enabled = false;
            Verify();
        }
        
        
    }
    
    public void Verify()
    {

        for (int i = 0; i<potetos.Length; i++)
        {
            Pos = dragArray[i].GetComponent<Drag>().OGPosition;
            print(Pos);
            //print(potetos[i].status);

            if (potetos[i].status.Equals(2))
            {
                potetos[i].GetComponent<Image>().color = Color.green;
                dragArray[i].GetComponent<Drag>().isDraggable = false;
            }

            else if (potetos[i].status.Equals(1)) 
            {
                potetos[i].GetComponent<Image>().color = Color.red;
                //drag.GetComponent<Transform>().position = Pos;
                //dragArray[i].GetComponent<Transform>().position = Pos;
            }

            else
            {
                potetos[i].GetComponent<Image>().color = Color.blue;
            }
        }
        AreAllElementsEqual(potetos, 2);

        
    }

    bool AreAllElementsEqual<T>(T[] array, int compareValue)
    {
        if (array == null || array.Length == 0)
            return true; // return true or throw exception as per your needs

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
