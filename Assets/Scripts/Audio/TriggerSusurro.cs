using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSusurro : MonoBehaviour
{

    private EventInstance Susurramen;
    public bool Hollow;
    public bool PasosLejanos;
    public bool Susurro;
    private bool AlreadyPlayed=false;

    private void Start()
    {
        
        if(Hollow)
        {
            Susurramen = AudioManager.instance.CreateInstance(FMODEvents.instance.HollowTube);
        }
        if(PasosLejanos)
        {
            Susurramen = AudioManager.instance.CreateEventInstanceObj(FMODEvents.instance.pasosLejanos, gameObject.transform);
        }
        else
        {
            Susurramen = AudioManager.instance.CreateInstance(FMODEvents.instance.Susurro);
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!AlreadyPlayed)
        {
            Susurramen.start();
            AlreadyPlayed = true;
        }
        
    }
}
