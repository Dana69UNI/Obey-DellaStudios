using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaUnlock : MonoBehaviour
{
    [field: Header("Puerta a desbloquear")]
    [field: SerializeField] public GameObject Puerta { get; private set; }

    [field: Header("Puerta a desbloquear")]
    [field: SerializeField] public GameObject Puerta2 { get; private set; }
    [field: Header("Puerta a desbloquear")]


    private doorUnlocker desbloqueaPuerta;
    private doorUnlocker desbloqueaPuerta2;


    private void Start()
    {
        desbloqueaPuerta = Puerta.GetComponent<doorUnlocker>();
        desbloqueaPuerta2 = Puerta2.GetComponent<doorUnlocker>();
    }

    // Update is called once per frame
    void Update()
    {
        float xRotation = transform.eulerAngles.x;
        if (xRotation > 180) xRotation -= 360;

        if (xRotation < -7f)
        {
            desbloqueaPuerta.DoorUnlock();
            desbloqueaPuerta2.DoorUnlock();
        }
    }
}
