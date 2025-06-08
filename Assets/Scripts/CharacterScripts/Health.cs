using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int Healthnum = 2;
   public void TakeDMG()
    {
        Healthnum--;
        if (Healthnum == 0 )
        {
            Debug.Log("moriteloco");
        }
    }
}
