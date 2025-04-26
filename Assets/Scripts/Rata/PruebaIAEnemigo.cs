using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PruebaIAEnemigo : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public float detectionRadius = 10f;
    public float wanderRadius = 20f;
    public float wanderTimer = 5f;

    private float timer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            // Persigue al jugador
            agent.SetDestination(player.position);
        }
        else
        {
            // Patrulla aleatoriamente
            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * dist;
        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    private void OnDrawGizmosSelected()
    {
        // Para que en el editor veas el rango de detección
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}