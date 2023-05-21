using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class SceneController : MonoBehaviour
{
    public Drop[] potetos;

    public void Verify()
    {

        for (int i = 0; i<potetos.Length; i++)
        {
            print(potetos[i].status);
            if (potetos[i].status.Equals(2))
            {

            }

            else if (potetos[i].status.Equals(1)) 
            {

            }

            else
            {

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
                return false;
        }

        return true;
    }


}
