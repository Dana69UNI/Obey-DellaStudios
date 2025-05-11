using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codigo_Pausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    private bool Pausa = false;

    void Start()
    {
        // Aseguramos que el juego empieza sin pausa
        Continuar();
    }

    void Update()
    {
        // Esto fuerza que el cursor esté visible mientras hacemos pruebas
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Pulsando ESC alternamos la pausa
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        ObjetoMenuPausa.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Pausa = true;
    }

    public void Continuar()
    {
        ObjetoMenuPausa.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Pausa = false;
    }

    public void Salir()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
