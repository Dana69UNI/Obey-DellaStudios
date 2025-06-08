using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleFinalManager : MonoBehaviour
{
    public static PuzzleFinalManager Instance;

    private int engranajesColocados = 0;
    public int totalEngranajes = 3;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void GearPlacedCorrectly()
    {
        engranajesColocados++;

        Debug.Log($"Engranajes colocados: {engranajesColocados}/{totalEngranajes}");

        if (engranajesColocados >= totalEngranajes)
        {
            Debug.Log("¡Puzzle completo! Cargando siguiente escena...");
            SceneManager.LoadScene(6);
        }
    }
}
