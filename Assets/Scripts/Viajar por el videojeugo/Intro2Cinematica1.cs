using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro2Cinematica1 : MonoBehaviour
{
    public GameObject Personaje;

    private void OnTriggerEnter(Collider other)
    {
        
            Destroy(Personaje);

            SceneManager.LoadScene(3);
        
    }
}
