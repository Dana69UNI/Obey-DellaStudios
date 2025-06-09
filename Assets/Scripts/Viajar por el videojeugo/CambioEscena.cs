using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public int IndiceEscena;
    public int IndiceEscenaDeseada;

    private void Start()
    {
        if(IndiceEscena == 7)
        {
            StartCoroutine(EsperarCinematica());
        }
        if(IndiceEscena == 3)
        {
            StartCoroutine(EsperarLecturaIntro1());
        }
        if (IndiceEscena == 4)
        {
            StartCoroutine(EsperarLecturaIntro1());
        }
        if (IndiceEscena == 6)
        {
            StartCoroutine(EsperarTrailer());
        }
    }

    IEnumerator EsperarCinematica()
    {
        yield return new WaitForSeconds(30f);
        SceneManager.LoadScene(IndiceEscenaDeseada);
    }

    IEnumerator EsperarLecturaIntro1()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(IndiceEscenaDeseada);
    }

    IEnumerator EsperarTrailer()
    {
        yield return new WaitForSeconds(44f);
        SceneManager.LoadScene(IndiceEscenaDeseada);
    }

}
