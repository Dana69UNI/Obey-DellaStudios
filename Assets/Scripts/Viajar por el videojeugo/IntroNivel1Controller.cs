using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroNivel1Controller : MonoBehaviour
{
    public string nombreSiguienteEscena = "NivelUno";
    public GameObject Personaje;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (Personaje != null)
            {
                Destroy(Personaje);
            }

            SceneManager.LoadScene(5); 
        }
    }
}

