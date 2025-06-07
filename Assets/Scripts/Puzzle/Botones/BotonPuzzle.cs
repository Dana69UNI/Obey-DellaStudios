using UnityEngine;

public class BotonPuzzle : MonoBehaviour
{
    public string colorBoton; // Asignar en el inspector: "Rojo", "Verde", etc.
    public PuzzleBotones puzzleManager;
    public Animator BotonBrillar;
    public Animator BotonBrillar2;
    public Animator BotonBrillar3;

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
            if (colorBoton == "Rojo")
            {
                BotonBrillar.SetTrigger("Brillar");
            }
            if (colorBoton == "Verde")
            {
                BotonBrillar.SetTrigger("Brillar2");
            }
            if (colorBoton == "Amarillo")
            {
                BotonBrillar.SetTrigger("Brillar3");
            }
            Debug.Log("Botón tocado: " + colorBoton);
            puzzleManager.BotonPulsado(colorBoton);

           
        }
    }
}
