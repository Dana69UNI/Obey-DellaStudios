//using UnityEngine;

//public class CameraCollision : MonoBehaviour
//{
//    Camera cam;
//    GameObject target;
//    RaycastHit hit;
//    float hitDistance;
//    Vector3 newPosition;

//    void Start()
//    {
//        cam = this.GetComponent<Camera>();
//    }

//    void Update()
//    {
//        target = GameObject.Find("Pivot");
//        hitDistance = 4;

//        if (Physics.Linecast(target.transform.position, this.transform.position, out hit))
//        {
//            Debug.DrawLine(target.transform.position, this.transform.position, Color.red);
//            Debug.DrawRay(hit.point, Vector3.back);
//            hitDistance = Mathf.Min(hitDistance, hit.distance);
//        }
//        else
//        {
//            Debug.DrawLine(target.transform.position, this.transform.position, Color.green);
//        }

//        if (hitDistance > 3)
//        {
//            hitDistance = 0;
//        }

//        Debug.Log(hitDistance);
//    }

//    private void LateUpdate()
//    {
//        newPosition = hit.point - Vector3.forward * 0.1f;
//        if (hitDistance > 0)
//        {
//            transform.position = newPosition;
//        }
//        else
//        {
//            transform.position = GameObject.Find("Target").transform.position;
//        }
//    }
//}








//using UnityEngine;

//public class CameraCollision : MonoBehaviour
//{
//    public Transform pivot;           // Punto de referencia detrás del personaje
//    public Transform defaultCamPos;   // Posición ideal de la cámara cuando no hay obstáculos

//    private RaycastHit hit;
//    private float hitDistance;
//    private Vector3 newPosition;

//    void Update()
//    {
//        hitDistance = 4;

//        if (Physics.Linecast(pivot.position, this.transform.position, out hit))
//        {
//            Debug.DrawLine(pivot.position, this.transform.position, Color.red);
//            Debug.DrawRay(hit.point, Vector3.back);
//            hitDistance = Mathf.Min(hitDistance, hit.distance);
//        }
//        else
//        {
//            Debug.DrawLine(pivot.position, this.transform.position, Color.green);
//        }

//        if (hitDistance > 3)
//        {
//            hitDistance = 0;
//        }

//        Debug.Log("Hit Distance: " + hitDistance);
//    }

//    private void LateUpdate()
//    {
//        if (hitDistance > 0)
//        {
//            newPosition = hit.point - Vector3.forward * 0.1f;
//            transform.position = newPosition;
//        }
//        else
//        {
//            transform.position = defaultCamPos.position;
//        }
//    }
//}



//using UnityEngine;

//public class CameraCollision : MonoBehaviour
//{
//    public Transform pivot;
//    public Transform defaultCamPos;

//    private RaycastHit hit;
//    private Vector3 newPosition;

//    void Update()
//    {
//        Vector3 direction = (defaultCamPos.position - pivot.position).normalized;
//        float maxDistance = Vector3.Distance(defaultCamPos.position, pivot.position);

//        if (Physics.Linecast(pivot.position, defaultCamPos.position, out hit))
//        {
//            Debug.DrawLine(pivot.position, hit.point, Color.red);
//            newPosition = hit.point - direction * 0.1f;
//        }
//        else
//        {
//            Debug.DrawLine(pivot.position, defaultCamPos.position, Color.green);
//            newPosition = defaultCamPos.position;
//        }
//    }

//    void LateUpdate()
//    {
//        transform.position = newPosition;
//    }
//}












//using UnityEngine;

//public class CameraCollision : MonoBehaviour
//{
//    public Transform target;           // El jugador o el punto a seguir
//    public float distance = 5.81f;        // Distancia ideal de la cámara
//    public float minDistance = 0.5f;   // Distancia mínima a la que puede acercarse la cámara al jugador
//    public float smoothSpeed = 10f;    // Velocidad de suavizado
//    public LayerMask collisionLayers;  // Capas con las que colisionará la cámara

//    private Vector3 currentVelocity;   // Para SmoothDamp

//    void LateUpdate()
//    {

//        // Vector desde el objetivo hacia la posición ideal de la cámara
//        Vector3 direction = (transform.position - target.position).normalized;

//        // Posición ideal sin colisiones
//        Vector3 idealPosition = target.position + direction * distance;

//        // Raycast para detectar obstáculos
//        RaycastHit hit;
//        if (Physics.Raycast(target.position, direction, out hit, distance, collisionLayers))
//        {
//            // Posición segura: un poco antes del obstáculo (para que no se pegue)
//            float adjustedDistance = Mathf.Clamp(hit.distance * 0.9f, minDistance, distance);

//            Vector3 targetPosition = target.position + direction * adjustedDistance;

//            // Suavizamos el movimiento para evitar saltos o temblores
//            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, 1f / smoothSpeed);
//        }
//        else
//        {
//            // Si no hay obstáculo, ir a la posición ideal suavemente
//            transform.position = Vector3.SmoothDamp(transform.position, idealPosition, ref currentVelocity, 1f / smoothSpeed);
//        }

//        // La cámara siempre mira al objetivo
//        transform.LookAt(target);
//    }
//}





using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform pivot;           // Punto de referencia, en teori va justo donde el jugador pero poniendolo asi se buguea y no funiona asi que lo he puesto un poco por detras del jugador
    public Transform defaultCamPos;   // Posición ideal de la cámara cuando no hay obstáculos (lo cual va un poco raro, ns si es impresión mia o no pero se me hace mayor distancia de la que esta la camara

    private RaycastHit hit;
    private float hitDistance;
    private Vector3 newPosition;

    void Update()
    {

        //Dejo todos los comentarios que le he pedido al chat para intentar entender algo porque heavy metal



        // Distancia máxima deseada de la cámara al pivot
        float maxDistance = Vector3.Distance(defaultCamPos.position, pivot.position);

        // Dirección desde pivot hacia cámara
        Vector3 direction = (defaultCamPos.position - pivot.position).normalized;

        // Hacemos linecast para ver si hay obstáculo entre pivot y cámara ideal
        if (Physics.Linecast(pivot.position, defaultCamPos.position, out hit))
        {
            Debug.DrawLine(pivot.position, hit.point, Color.red);

            hitDistance = hit.distance;

            // Movemos la cámara para que quede justo antes del obstáculo (un poco separado)
            newPosition = pivot.position + direction * (hitDistance - 0.1f);
        }
        else
        {
            Debug.DrawLine(pivot.position, defaultCamPos.position, Color.green);

            // No hay obstáculo, la cámara va a su posición ideal
            newPosition = defaultCamPos.position;
            hitDistance = maxDistance;
        }

        Debug.Log("Hit Distance: " + hitDistance);
    }

    private void LateUpdate()
    {
        // Movemos la cámara a la posición calculada en Update()
        transform.position = newPosition;
    }
}





//using UnityEngine;

//public class CameraCollision : MonoBehaviour
//{
//    public Transform pivot;           // Punto de referencia (normalmente el jugador o un empty cerca)
//    public Transform defaultCamPos;  // Posición ideal de la cámara cuando no hay obstáculos

//    public float smoothSpeed = 10f;  // Velocidad de suavizado para el movimiento de cámara
//    public float offset = 0.1f;      // Pequeña separación para que la cámara no choque justo con la pared

//    private Vector3 newPosition;

//    void Start()
//    {
//        // Inicializamos newPosition en la posición ideal al inicio
//        newPosition = defaultCamPos.position;
//    }

//    void Update()
//    {
//        // Calculamos la dirección desde el pivot hacia la posición ideal de la cámara
//        Vector3 direction = (defaultCamPos.position - pivot.position).normalized;

//        // Distancia máxima que queremos entre pivot y cámara
//        float maxDistance = Vector3.Distance(defaultCamPos.position, pivot.position);

//        RaycastHit hit;

//        // Hacemos un Linecast para detectar si hay obstáculos entre pivot y cámara ideal
//        if (Physics.Linecast(pivot.position, defaultCamPos.position, out hit))
//        {
//            Debug.DrawLine(pivot.position, hit.point, Color.red);

//            // Ajustamos la posición para que la cámara quede justo antes del obstáculo (con un pequeño offset)
//            newPosition = pivot.position + direction * (hit.distance - offset);
//        }
//        else
//        {
//            Debug.DrawLine(pivot.position, defaultCamPos.position, Color.green);

//            // No hay obstáculo, cámara en posición ideal
//            newPosition = defaultCamPos.position;
//        }
//    }

//    void LateUpdate()
//    {
//        // Movemos la cámara suavemente hacia la posición calculada
//        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothSpeed);

//        // La cámara mira siempre al pivot
//        transform.LookAt(pivot);
//    }
//}
