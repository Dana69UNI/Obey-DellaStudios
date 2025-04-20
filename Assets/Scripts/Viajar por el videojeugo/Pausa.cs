using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codigo_Pausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public bool Pausa = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa == false)
            {
                ObjetoMenuPausa.SetActive(true);
                Pausa = true;

                Time.timeScale = 0;
            }
            else
            {
                ObjetoMenuPausa.SetActive(false);
                Time.timeScale = 1f;
                Pausa = false;
            }

        }
    }
}
