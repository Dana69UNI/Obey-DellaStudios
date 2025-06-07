using UnityEngine;

public class BotonPuzzle : MonoBehaviour
{
    public string colorBoton; // Asignar en el inspector: "Rojo", "Verde", etc.
    public PuzzleBotones puzzleManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand.L") || other.CompareTag("Hand.R") || other.CompareTag("Player")) // Aseg�rate de que el jugador tenga el tag "Player"
        {
            Debug.Log("Bot�n tocado: " + colorBoton);
            puzzleManager.BotonPulsado(colorBoton);
        }
    }
}
