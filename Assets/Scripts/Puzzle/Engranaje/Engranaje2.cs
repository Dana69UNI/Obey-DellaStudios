using UnityEngine;

public class Engranaje2 : MonoBehaviour
{
    private Animator animatorEngranaje;
    //public Animator animatorPuerta;
    public Animator animatorEngranaje2;
    public Animator animatorEngranaje3;
    public GameObject EngranajeCorrecto;
    public GameObject Llave;

    private Rigidbody rb;
    private bool yaPegado = false;

    private void Awake()
    {
        Llave.SetActive(false);
        rb = EngranajeCorrecto.GetComponent<Rigidbody>();
        animatorEngranaje = EngranajeCorrecto.GetComponent<Animator>();
        animatorEngranaje.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (yaPegado) return;

        if (other.CompareTag("Engranaje2"))
        {
            // Paramos física para que no interfiera
            rb.isKinematic = true;
            rb.useGravity = false;

            // Teletransportamos al punto exacto
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;

            yaPegado = true;
            animatorEngranaje.enabled = true;
            animatorEngranaje.SetTrigger("rotar");
            Llave.SetActive(true);
            //animatorPuerta.SetTrigger("abrir");
            animatorEngranaje2.SetTrigger("rotar");
            animatorEngranaje3.SetTrigger("rotar");


        }
    }
}