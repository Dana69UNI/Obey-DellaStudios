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
    public Transform VisionPos;
    private float timer = 0;
    private bool SoundWander =false;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        timer += Time.deltaTime;
        AiState();
    }

    private void AiState()
    {
        if(!SoundWander)
        {
            float distanceToPlayer = Vector3.Distance(VisionPos.position, player.position);

            if (distanceToPlayer <= detectionRadius)
            {

                agent.SetDestination(player.position);
            }
            else
            {

                if (timer >= wanderTimer)
                {
                    Vector3 newPos = RandomNavSphere(VisionPos.position, wanderRadius, -1);
                    agent.SetDestination(newPos);
                    timer = 0;
                }
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
        Gizmos.DrawWireSphere(VisionPos.position, detectionRadius);
    }

    public void SoundCheck(Vector3 pos)
    {
        SoundWander = true;
        Debug.Log("escuché eso viejo");
        agent.SetDestination(pos);
        StartCoroutine(SoundWanderCd());
    }

    IEnumerator SoundWanderCd()
    {
        yield return new WaitForSeconds(4f);
        SoundWander =false;
    }
}