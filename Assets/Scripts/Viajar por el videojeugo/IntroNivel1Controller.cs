using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroNivel1Controller : MonoBehaviour
{
    public string nombreSiguienteEscena = "NivelUno";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(5);
        }
    }
}
