using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViajarEnVideojuego : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public void Jugar()
    {
        SceneManager.LoadScene(1);
    }
    public void Salir()
    {
        Application.Quit();

        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    
    public void Continuar()
    {
        ObjetoMenuPausa.SetActive(false); // Oculta el menú de pausa
        Time.timeScale = 1f; // Reanuda el tiempo
    }
}