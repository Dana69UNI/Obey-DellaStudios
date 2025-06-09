using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
public class StepSound : MonoBehaviour
{
    private EventInstance PasosPersonaje;
    private void Start()
    {
        PasosPersonaje = AudioManager.instance.CreateInstance(FMODEvents.instance.playerSteps);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 2.5f)
        {
            PasosPersonaje.start();
        }
    }
}
