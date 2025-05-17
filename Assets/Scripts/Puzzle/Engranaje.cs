using UnityEngine;

public class Engranaje : MonoBehaviour
{
    public Animator animatorEngranaje;
    public Animator animatorPuerta;
    public Animator animatorEngranaje2;
    public Animator animatorEngranaje3;

    private Rigidbody rb;
    private bool yaPegado = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (yaPegado) return;

        if (other.CompareTag("PuntoEngranaje"))
        {
            // Paramos física para que no interfiera
            rb.isKinematic = true;
            rb.useGravity = false;

            // Teletransportamos al punto exacto
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;

            yaPegado = true;

            animatorEngranaje.SetTrigger("rotar");
            animatorPuerta.SetTrigger("abrir");
            animatorEngranaje2.SetTrigger("rotar");
            animatorEngranaje3.SetTrigger("rotar");

           
        }
    }
}
