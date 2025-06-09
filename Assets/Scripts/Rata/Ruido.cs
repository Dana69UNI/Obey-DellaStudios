using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruido : MonoBehaviour
{
    public float radioRuido = 10f;
    private EventInstance Ruiditoo;
    private PruebaIAEnemigo enemigoIa;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Ruiditoo = AudioManager.instance.CreateEventInstanceObj(FMODEvents.instance.ObjetoHitSuelo, gameObject.transform);
        if (collision.relativeVelocity.magnitude > 4f)
        {
            Ruiditoo.start();
        }
            if (!collision.collider.CompareTag("Rata"))
        {
            
            if (collision.relativeVelocity.magnitude > 12f)
            {
                EmitirRuido();
            }
        }
      
    }

    void EmitirRuido()
    {
        // Detecta a los enemigos en el área de radioRuido
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioRuido);
        foreach (Collider col in colliders)
        {
            enemigoIa = col.GetComponent<PruebaIAEnemigo>();
            if (enemigoIa != null)
            {
                // Llama al método EscucharRuido del enemigo
                enemigoIa.SoundCheck(transform.position);
            }
        }
    }
}
