using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{

    [field: Header("Music")]
    [field: SerializeField] public EventReference music { get; private set; }


    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference playerSteps { get; private set; }

    [field: SerializeField] public EventReference ObjetoHitSuelo { get; private set; }

    [field: SerializeField] public EventReference Susurro { get; private set; }

    [field: SerializeField] public EventReference HollowTube { get; private set; }

    [field: SerializeField] public EventReference pasosLejanos { get; private set; }

    [field: SerializeField] public EventReference Cinematica1 { get; private set; }

    [field: SerializeField] public EventReference Cinematica2 { get; private set; }
    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the scene.");
        }
        instance = this;
    }
}