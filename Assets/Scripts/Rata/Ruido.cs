using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruido : MonoBehaviour
{
    public float radioRuido = 10f;

    void OnCollisionEnter(Collision collision)
    {
        // Cuando toca algo (suelo, pared, etc), hace ruido
        EmitirRuido();
    }

    void EmitirRuido()
    {
        // Detecta a los enemigos en el área de radioRuido
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioRuido);
        foreach (Collider col in colliders)
        {
            NavMeshEnemigo enemigo = col.GetComponent<NavMeshEnemigo>();
            if (enemigo != null)
            {
                // Llama al método EscucharRuido del enemigo
                enemigo.EscucharRuido(transform.position);
            }
        }
    }
}
