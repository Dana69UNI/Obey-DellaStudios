using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engranaje : MonoBehaviour
{
    public Transform snapPoint; // Punto en la pared donde se "pega"
    public Animator gearAnimator;
    public DoorController door; // Referencia a la puerta
    private bool isAttached = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isAttached && other.CompareTag("Player"))
        {
            AttachToWall();
        }
    }

    void AttachToWall()
    {
        isAttached = true;
        transform.position = snapPoint.position;
        transform.rotation = snapPoint.rotation;
        transform.parent = snapPoint; // Para que se quede pegado

        gearAnimator.SetTrigger("Rotate");
        door.OpenDoor();
    }
}