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
//    public Transform pivot;           // Punto de referencia detr�s del personaje
//    public Transform defaultCamPos;   // Posici�n ideal de la c�mara cuando no hay obst�culos

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
//    public float distance = 5.81f;        // Distancia ideal de la c�mara
//    public float minDistance = 0.5f;   // Distancia m�nima a la que puede acercarse la c�mara al jugador
//    public float smoothSpeed = 10f;    // Velocidad de suavizado
//    public LayerMask collisionLayers;  // Capas con las que colisionar� la c�mara

//    private Vector3 currentVelocity;   // Para SmoothDamp

//    void LateUpdate()
//    {

//        // Vector desde el objetivo hacia la posici�n ideal de la c�mara
//        Vector3 direction = (transform.position - target.position).normalized;

//        // Posici�n ideal sin colisiones
//        Vector3 idealPosition = target.position + direction * distance;

//        // Raycast para detectar obst�culos
//        RaycastHit hit;
//        if (Physics.Raycast(target.position, direction, out hit, distance, collisionLayers))
//        {
//            // Posici�n segura: un poco antes del obst�culo (para que no se pegue)
//            float adjustedDistance = Mathf.Clamp(hit.distance * 0.9f, minDistance, distance);

//            Vector3 targetPosition = target.position + direction * adjustedDistance;

//            // Suavizamos el movimiento para evitar saltos o temblores
//            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, 1f / smoothSpeed);
//        }
//        else
//        {
//            // Si no hay obst�culo, ir a la posici�n ideal suavemente
//            transform.position = Vector3.SmoothDamp(transform.position, idealPosition, ref currentVelocity, 1f / smoothSpeed);
//        }

//        // La c�mara siempre mira al objetivo
//        transform.LookAt(target);
//    }
//}





using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform pivot;           // Punto de referencia, en teori va justo donde el jugador pero poniendolo asi se buguea y no funiona asi que lo he puesto un poco por detras del jugador
    public Transform defaultCamPos;   // Posici�n ideal de la c�mara cuando no hay obst�culos (lo cual va un poco raro, ns si es impresi�n mia o no pero se me hace mayor distancia de la que esta la camara

    private RaycastHit hit;
    private float hitDistance;
    private Vector3 newPosition;

    void Update()
    {

        //Dejo todos los comentarios que le he pedido al chat para intentar entender algo porque heavy metal



        // Distancia m�xima deseada de la c�mara al pivot
        float maxDistance = Vector3.Distance(defaultCamPos.position, pivot.position);

        // Direcci�n desde pivot hacia c�mara
        Vector3 direction = (defaultCamPos.position - pivot.position).normalized;

        // Hacemos linecast para ver si hay obst�culo entre pivot y c�mara ideal
        if (Physics.Linecast(pivot.position, defaultCamPos.position, out hit))
        {
            Debug.DrawLine(pivot.position, hit.point, Color.red);

            hitDistance = hit.distance;

            // Movemos la c�mara para que quede justo antes del obst�culo (un poco separado)
            newPosition = pivot.position + direction * (hitDistance - 0.1f);
        }
        else
        {
            Debug.DrawLine(pivot.position, defaultCamPos.position, Color.green);

            // No hay obst�culo, la c�mara va a su posici�n ideal
            newPosition = defaultCamPos.position;
            hitDistance = maxDistance;
        }

        Debug.Log("Hit Distance: " + hitDistance);
    }

    private void LateUpdate()
    {
        // Movemos la c�mara a la posici�n calculada en Update()
        transform.position = newPosition;
    }
}





//using UnityEngine;

//public class CameraCollision : MonoBehaviour
//{
//    public Transform pivot;           // Punto de referencia (normalmente el jugador o un empty cerca)
//    public Transform defaultCamPos;  // Posici�n ideal de la c�mara cuando no hay obst�culos

//    public float smoothSpeed = 10f;  // Velocidad de suavizado para el movimiento de c�mara
//    public float offset = 0.1f;      // Peque�a separaci�n para que la c�mara no choque justo con la pared

//    private Vector3 newPosition;

//    void Start()
//    {
//        // Inicializamos newPosition en la posici�n ideal al inicio
//        newPosition = defaultCamPos.position;
//    }

//    void Update()
//    {
//        // Calculamos la direcci�n desde el pivot hacia la posici�n ideal de la c�mara
//        Vector3 direction = (defaultCamPos.position - pivot.position).normalized;

//        // Distancia m�xima que queremos entre pivot y c�mara
//        float maxDistance = Vector3.Distance(defaultCamPos.position, pivot.position);

//        RaycastHit hit;

//        // Hacemos un Linecast para detectar si hay obst�culos entre pivot y c�mara ideal
//        if (Physics.Linecast(pivot.position, defaultCamPos.position, out hit))
//        {
//            Debug.DrawLine(pivot.position, hit.point, Color.red);

//            // Ajustamos la posici�n para que la c�mara quede justo antes del obst�culo (con un peque�o offset)
//            newPosition = pivot.position + direction * (hit.distance - offset);
//        }
//        else
//        {
//            Debug.DrawLine(pivot.position, defaultCamPos.position, Color.green);

//            // No hay obst�culo, c�mara en posici�n ideal
//            newPosition = defaultCamPos.position;
//        }
//    }

//    void LateUpdate()
//    {
//        // Movemos la c�mara suavemente hacia la posici�n calculada
//        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothSpeed);

//        // La c�mara mira siempre al pivot
//        transform.LookAt(pivot);
//    }
//}
