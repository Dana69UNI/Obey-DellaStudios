using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleFinalManager : MonoBehaviour
{
    public static PuzzleFinalManager Instance;

    private int engranajesColocados = 0;
    public int totalEngranajes = 3;
    private bool Eng1;
    private bool Eng2;
    private bool Eng3;
    public Engranaje eng1;
    public Engranaje2 eng2;
    public Engranaje3 eng3;
    private void Awake()
    {
        
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if(eng1.yaPegado)
        {
            Eng1 = true;
        }
        if (eng2.yaPegado)
        {
            Eng2 = true;
        }
        if (eng3.yaPegado)
        {
            Eng3 = true;
        }
        if(Eng1 && Eng2 && Eng3)
        {
            SceneManager.LoadScene(6);
        }
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
