using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
public class CinematixAudioPlayer : MonoBehaviour
{
    private EventInstance SonidoCinematica;
    public bool Escena1;
    void Start()
    {
        if(Escena1)
        {
            SonidoCinematica = AudioManager.instance.CreateInstance(FMODEvents.instance.Cinematica1);
        }
        else
        {
            SonidoCinematica = AudioManager.instance.CreateInstance(FMODEvents.instance.Cinematica2);
        }


        SonidoCinematica.start();
    }


    private void OnDisable()
    {
        SonidoCinematica.stop(STOP_MODE.ALLOWFADEOUT);
    }

    private void OnDestroy()
    {
        SonidoCinematica.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
