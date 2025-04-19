using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float moveRadius = 10f;
    public float speed = 3f;
    public float obstacleDetectionDistance = 1f;
    public LayerMask obstacleLayer; // para paredes
    public LayerMask playerLayer;   // para detectar al jugador
    public float visionDistance = 10f; // hasta dónde puede "ver" al jugador

    private Vector3 targetPosition;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        NuevaPosicion();
    }

    void Update()
    {
        // Mira si el jugador está en la línea de visión
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Raycast hacia el jugador
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

        // Si no ve al jugador, patrulla
        Vector3 directionToTarget = (targetPosition - transform.position).normalized;

        if (Physics.Raycast(transform.position, directionToTarget, obstacleDetectionDistance, obstacleLayer))
        {
            NuevaPosicion();
        }
        else
        {
            MoverHacia(targetPosition);

            if (Vector3.Distance(transform.position, targetPosition) < 0.2f)
            {
                NuevaPosicion();
            }
        }
    }

    void MoverHacia(Vector3 destino)
    {
        destino.y = transform.position.y; // Mantener altura
        transform.position = Vector3.MoveTowards(transform.position, destino, speed * Time.deltaTime);
    }

    void NuevaPosicion()
    {
        Vector3 randomDirection = new Vector3(
            Random.Range(-moveRadius, moveRadius),
            0f,
            Random.Range(-moveRadius, moveRadius)
        );

        targetPosition = transform.position + randomDirection;
        targetPosition.y = transform.position.y;
    }
}
