using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BotonPuzzle : MonoBehaviour
{
    public string colorBoton; // Asignar en el inspector: "Rojo", "Verde", etc.
    public PuzzleBotones puzzleManager;
    public Animator BotonBrillar;
    public Animator BotonBrillar2;
    public Animator BotonBrillar3;
    bool canPress = true;

    private void Start()
    {
        BotonBrillar = GetComponent<Animator>();
        BotonBrillar2 = GetComponent<Animator>();
        BotonBrillar3 = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand.L") || other.CompareTag("Hand.R") || other.CompareTag("Player")) // Asegúrate de que el jugador tenga el tag "Player"
        {
            if (!canPress)
            {
            }
            else
            {
                if (colorBoton == "Rojo")
                {
                    BotonBrillar.SetTrigger("Brillar");
                    canPress = false;
                    StartCoroutine(CoolDownPresionar());
                }
                if (colorBoton == "Verde")
                {
                    BotonBrillar.SetTrigger("Brillar2");
                    canPress = false;
                    StartCoroutine(CoolDownPresionar());
                }
                if (colorBoton == "Amarillo")
                {
                    BotonBrillar.SetTrigger("Brillar3");
                    canPress = false;
                    StartCoroutine(CoolDownPresionar());
                }
                Debug.Log("Botón tocado: " + colorBoton);
                puzzleManager.BotonPulsado(colorBoton);
            }
           

           
        }
    }
    IEnumerator CoolDownPresionar()
    {
        yield return new WaitForSeconds(1f);
        canPress=true;
    }
}
