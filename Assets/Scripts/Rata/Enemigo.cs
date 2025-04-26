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
}
