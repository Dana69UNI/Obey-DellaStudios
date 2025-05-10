using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemigo : MonoBehaviour
{
    public GameObject player;  // El jugador
    public float radioVision = 10f;  // Radio de visión para detectar al jugador
    public float distanciaPatrullaje = 10f;  // Distancia máxima para la patrulla
    public float tiempoEntrePatrullas = 3f;  // Tiempo entre cambios de destino de patrullaje

    private NavMeshAgent agente;  // Agente de navegación
    private Vector3 destinoPatrulla;  // Destino actual de la patrulla
    private float cronometro;
    private bool investigandoRuido = false;  // Para saber si el enemigo está investigando el ruido
    private Vector3 puntoRuido;  // El punto donde ocurrió el ruido

    void Start()
    {
        player = GameObject.Find("Player");  // Encuentra el jugador
        agente = GetComponent<NavMeshAgent>();  // Obtén el componente NavMeshAgent
        cronometro = tiempoEntrePatrullas;  // Inicializa el cronómetro
        ElegirNuevoDestinoPatrulla();  // Inicia la patrulla
    }

    void Update()
    {
        if (investigandoRuido)
        {
            // Si el enemigo está investigando el ruido, va a la ubicación del ruido
            agente.SetDestination(puntoRuido);

            // Si el enemigo llega al punto de ruido, comienza a patrullar nuevamente
            if (!agente.pathPending && agente.remainingDistance < 0.5f)
            {
                investigandoRuido = false;
                ElegirNuevoDestinoPatrulla();  // Vuelve a patrullar
            }
        }
        else
        {
            // Si el enemigo no está investigando el ruido, patrulla
            float distanciaAlJugador = Vector3.Distance(transform.position, player.transform.position);

            if (distanciaAlJugador <= radioVision)
            {
                // Si el jugador está dentro del rango de visión, persigue al jugador
                agente.SetDestination(player.transform.position);
            }
            else
            {
                // Patrullando
                if (!agente.pathPending && agente.remainingDistance < 0.5f)
                {
                    cronometro -= Time.deltaTime;  // Cuenta el tiempo para elegir un nuevo punto

                    if (cronometro <= 0)
                    {
                        ElegirNuevoDestinoPatrulla();  // Elige un nuevo punto de patrullaje
                        cronometro = tiempoEntrePatrullas;  // Resetea el cronómetro
                    }
                }
            }
        }
    }

    void ElegirNuevoDestinoPatrulla()
    {
        // Genera un punto aleatorio dentro de un rango en el NavMesh
        Vector3 randomDirection = Random.insideUnitSphere * distanciaPatrullaje;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, distanciaPatrullaje, NavMesh.AllAreas))
        {
            destinoPatrulla = hit.position;
            agente.SetDestination(destinoPatrulla);  // Asigna el nuevo destino de patrullaje
        }
    }

    // Método para escuchar el ruido y empezar a investigar
    public void EscucharRuido(Vector3 puntoRuidoDetectado)
    {
        // Solo comenzamos a investigar si no estamos persiguiendo al jugador
        if (!investigandoRuido)
        {
            investigandoRuido = true;  // El enemigo empieza a investigar el ruido
            puntoRuido = puntoRuidoDetectado;  // Asigna el punto de ruido
            agente.SetDestination(puntoRuido);  // Se dirige al punto donde se emitió el ruido
        }
    }
}




