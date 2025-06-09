using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class FadeTransicion : MonoBehaviour
{
    public Animator animadorFade;
    public string nombreEscenaDestino = "IntroNivel0";

    public void IniciarTransicion()
    {
        Debug.Log("Iniciando transición");
        StartCoroutine(FadeYViajar());
    }

    IEnumerator FadeYViajar()
    {
        animadorFade.SetTrigger("FadeOut");
        float timer = 0f;
    while (timer < 3f)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(7);
    }
}

