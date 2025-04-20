using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject MenuPausa;
    public bool Pausa = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Pausa == false)
            {
                MenuPausa.SetActive(true);
                Pausa = true;
            }
        }
    }
}
