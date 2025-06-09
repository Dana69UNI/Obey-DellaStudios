using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
public class initiazeMusic : MonoBehaviour
{
    private EventInstance MusicaMenu;
 
    void Start()
    {
        MusicaMenu = AudioManager.instance.CreateInstance(FMODEvents.instance.music);
      
        MusicaMenu.start();
    }


    private void OnDisable()
    {
        MusicaMenu.stop(STOP_MODE.ALLOWFADEOUT);
    }

    private void OnDestroy()
    {
        MusicaMenu.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
