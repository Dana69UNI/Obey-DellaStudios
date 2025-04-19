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
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioRuido);
        foreach (Collider col in colliders)
        {
            Enemigo enemigo = col.GetComponent<Enemigo>();
            if (enemigo != null)
            {
                enemigo.EscucharRuido(transform.position);
            }
        }
    }
}
