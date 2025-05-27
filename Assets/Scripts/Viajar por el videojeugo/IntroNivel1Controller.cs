using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroNivel1Controller : MonoBehaviour
{
    public float tiempoEspera = 3f; // Tiempo antes de cargar la siguiente escena
    public string nombreSiguienteEscena = "NivelUno";

    void Start()
    {
        StartCoroutine(CambiarEscenaDespues());
    }

    IEnumerator CambiarEscenaDespues()
    {
        yield return new WaitForSeconds(tiempoEspera);
        SceneManager.LoadScene(5);
    }
}

