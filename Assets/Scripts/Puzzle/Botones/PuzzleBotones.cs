using UnityEngine;
using System.Collections.Generic;

public class PuzzleBotones : MonoBehaviour
{
    public List<string> ordenCorrecto = new List<string> { "Rojo", "Amarillo", "Verde" };
    private List<string> ordenJugador = new List<string>();

    public GameObject llave; // Objeto llave que se activa al completar el puzzle

    private void Start()
    {
        llave.SetActive(false);
    }

    public void BotonPulsado(string color)
    {
        ordenJugador.Add(color);

        // Comprobamos en cada paso
        for (int i = 0; i < ordenJugador.Count; i++)
        {
            if (ordenJugador[i] != ordenCorrecto[i])
            {
                Debug.Log("¡Secuencia incorrecta! Reiniciando...");
                ordenJugador.Clear();
                return;
            }
        }

        // Si acierta todos
        if (ordenJugador.Count == ordenCorrecto.Count)
        {
            Debug.Log("Puzzle resuelto");
            llave.SetActive(true);
        }
    }
}
