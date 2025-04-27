using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorUnlocker : MonoBehaviour
{
    Rigidbody Puerta;
    void Start()
    {
        Puerta = GetComponent<Rigidbody>();
        Puerta.freezeRotation = true;
    }

    public void DoorUnlock()
    {
        Puerta.freezeRotation = false;
    }
}
