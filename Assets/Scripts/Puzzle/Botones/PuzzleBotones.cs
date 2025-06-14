using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PuzzleBotones : MonoBehaviour
{
    public List<string> ordenCorrecto = new List<string> { "Rojo", "Amarillo", "Verde" };
    private List<string> ordenJugador = new List<string>();
    public Animator Color;
    bool canPress = true;
   

    public GameObject llave; // Objeto llave que se activa al completar el puzzle

    private void Start()
    {
        llave.SetActive(false);
        Color = GetComponent<Animator>();
       
    }

    public void BotonPulsado(string color)
    {
        ordenJugador.Add(color);

        // Comprobamos en cada paso
        for (int i = 0; i < ordenJugador.Count; i++)
        {
            if (ordenJugador[i] != ordenCorrecto[i])
            {
                Debug.Log("ĄSecuencia incorrecta! Reiniciando...");
                ordenJugador.Clear();
                Color.SetTrigger("Incorrecto");

                return;
            }
        }

        // Si acierta todos
        if (ordenJugador.Count == ordenCorrecto.Count)
        {

            Debug.Log("Puzzle resuelto");
            llave.SetActive(true);
           
            Color.SetTrigger("Correcto");
           
        }
    }

    IEnumerator CoolDownPresionar()
    {
        yield return new WaitForSeconds(1f);
        canPress = true;
    }
}
