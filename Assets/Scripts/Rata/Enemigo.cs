using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float moveRadius = 10f;
    public float speed = 3f;
    public float obstacleDetectionDistance = 2f;
    public LayerMask obstacleLayer; // para paredes
    public LayerMask playerLayer;   // para detectar al jugador
    public float visionDistance = 10f; // hasta dónde puede "ver" al jugador
    public float pushForce = 5f; // (puesto por Pablo) Fuerza de empuje, modificable desde el editor

    private Vector3 targetPosition;
    private Transform player;

    private bool investigandoRuido = false;
    private Vector3 posicionRuido;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        NuevaPosicion();
    }

    void Update()
    {
        // Si ha llegado a su destino y no está haciendo otra cosa, buscar nueva posición
        if (!investigandoRuido && Vector3.Distance(transform.position, targetPosition) < 0.2f)
        {
            NuevaPosicion();
        }

        // Mira si el jugador está en la línea de visión
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        Ray ray = new Ray(transform.position, directionToPlayer);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, visionDistance, obstacleLayer | playerLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                // Persigue al jugador
                MoverHacia(player.position);
                return;
            }
        }

        // Si está investigando un ruido
        if (investigandoRuido)
        {
            MoverHacia(posicionRuido);

            if (Vector3.Distance(transform.position, posicionRuido) < 0.5f)
            {
                investigandoRuido = false;
                NuevaPosicion(); // vuelve a patrullar
            }

            return;
        }

        // Patrullaje normal
        Vector3 directionToTarget = (targetPosition - transform.position).normalized;

        if (Physics.Raycast(transform.position, directionToTarget, obstacleDetectionDistance, obstacleLayer))
        {
            NuevaPosicion();
        }
        else
        {
            MoverHacia(targetPosition);
        }
    }

    void MoverHacia(Vector3 destino)
    {
        destino.y = transform.position.y; // Mantener altura
        transform.position = Vector3.MoveTowards(transform.position, destino, speed * Time.deltaTime);
    }

    void NuevaPosicion()
    {
        Vector3 randomDirection;
        float distanciaMinima = 2f;

        do
        {
            randomDirection = new Vector3(
                Random.Range(-moveRadius, moveRadius),
                0f,
                Random.Range(-moveRadius, moveRadius)
            );
        }
        while (randomDirection.magnitude < distanciaMinima);

        targetPosition = transform.position + randomDirection;
        targetPosition.y = transform.position.y;
    }

    public void EscucharRuido(Vector3 posicion)
    {
        posicionRuido = posicion;
        investigandoRuido = true;
    }

    //(funcion puesta por Pablo)
    private void OnCollisionEnter(Collision collision)
    {
        // Primero miramos si el objeto con el que ha colisionado tiene el layer "Player"
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Tomamos o miramos la posicion del jugador
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                Vector3 pushDirection = collision.transform.position - transform.position; //Pillamos la posicion del player con el que hemos colisionado y luego lo restamos con la posicion del enemigo para empujarlo hacia la otra direccion
                pushDirection.y = 0; // esto es por si queremos que empuje hacia arriba, de momento esta en 0 asi que solo empuja horizontalmente
                pushDirection.Normalize();

                playerRb.AddForce(pushDirection * pushForce, ForceMode.Impulse); //Con todas las direcciones pilladas, lo empujamos
            }
        }
    }
}




//Vector3 direccionAlRuido = (posicion - transform.position).normalized;
//float distanciaAlRuido = Vector3.Distance(transform.position, posicion);

//RaycastHit hit;
//if (Physics.Raycast(transform.position, direccionAlRuido, out hit, distanciaAlRuido))
//{
//    // Si el raycast golpea algo...
//    if (((1 << hit.collider.gameObject.layer) & obstacleLayer) != 0)
//    {
//        // ...y es un obstáculo, NO escucha el ruido
//        return;
//    }
//}