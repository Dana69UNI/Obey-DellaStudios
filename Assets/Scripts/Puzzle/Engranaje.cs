using UnityEngine;

public class Engranaje : MonoBehaviour
{
    public Animator animatorEngranaje;  // Arrástralos en Inspector
    public Animator animatorPuerta;

    private Rigidbody rb;
    private bool yaPegado = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si ya está pegado, no hacemos nada
        if (yaPegado)
            return;

        // Comprobamos si entramos en contacto con el punto de pegado
        if (other.CompareTag("PuntoEngranaje"))
        {
            // Hacemos kinematic para que la física no interfiera
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

            // Teletransportamos el engranaje a la posición y rotación exacta del punto
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;

            yaPegado = true;

            // Activamos las animaciones
            animatorEngranaje.SetTrigger("rotar");
            animatorPuerta.SetTrigger("abrir");
        }
    }
}
