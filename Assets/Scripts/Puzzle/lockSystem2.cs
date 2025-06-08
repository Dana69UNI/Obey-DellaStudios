using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockSystem2 : MonoBehaviour
{
    [field: Header("GameObject Unlock")]
    [field: SerializeField] public GameObject KeyItem { get; private set; }

    [field: Header("GameObject wrong")]
    [field: SerializeField] public GameObject WrongItem { get; private set; }

    [field: Header("GameObject wrong2")]
    [field: SerializeField] public GameObject WrongItem2 { get; private set; }

    [field: Header("Puerta a desbloquear")]
    [field: SerializeField] public GameObject Puerta { get; private set; }

    [field: Header("Puerta a desbloquear")]
    [field: SerializeField] public GameObject Puerta2 { get; private set; }
    [field: Header("Puerta a desbloquear")]
    [field: SerializeField] public GameObject PuertaTaquilla { get; private set; }

    Rigidbody wrongRB;
    public bool Taquilla;

    private doorUnlocker desbloqueaPuerta;
    private doorUnlocker desbloqueaPuerta2;

    private void Start()
    {
        if (desbloqueaPuerta != null)
        {

            desbloqueaPuerta = Puerta.GetComponent<doorUnlocker>();
            desbloqueaPuerta2 = Puerta2.GetComponent<doorUnlocker>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == KeyItem)
        {
            Destroy(KeyItem);
            if(Taquilla)
            {
                Destroy(PuertaTaquilla);

            }
            if (Puerta != null)
            {
                desbloqueaPuerta.DoorUnlock();
            }
            if (Puerta2 != null)
            {
                desbloqueaPuerta2.DoorUnlock();
            }
            Destroy(this.gameObject);
        }
        if (other.gameObject == WrongItem || other.gameObject == WrongItem2)
        {
            wrongRB = other.GetComponent<Rigidbody>();
            wrongRB.AddForce(15f * Vector3.forward, ForceMode.Impulse);

        }
    }
}
