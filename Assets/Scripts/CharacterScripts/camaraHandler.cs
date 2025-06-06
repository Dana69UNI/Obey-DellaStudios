using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 3f, -6f);
    public float distance = 6f;

    [Header("Rotation")]
    public float sensitivity = 2f;
    public float rotationSmoothTime = 0.12f;
    public float minVerticalAngle = -27f; //luego se ajustan bien estos valores en el inspector
    public float maxVerticalAngle = 90f;

    public InputActionReference lookInput;

    private Vector2 currentRotation;
    private Vector2 rotationSmoothVelocity;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        if (lookInput != null)
            lookInput.action.Enable();
    }

    private void OnDisable()
    {
        if (lookInput != null)
            lookInput.action.Disable();
    }

    private void LateUpdate()
    {
        CameraHandling();
    }

    //private void CameraHandling()
    //{
    //    if (target == null || lookInput == null) return;


    //    Vector2 lookDelta = lookInput.action.ReadValue<Vector2>() * sensitivity;

    //    currentRotation.x += lookDelta.x;
    //    currentRotation.y -= lookDelta.y;


    //    currentRotation.y = Mathf.Clamp(currentRotation.y, minVerticalAngle, maxVerticalAngle);

    //    Quaternion rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0f);


    //    Vector3 targetPosition = target.position - rotation * Vector3.forward * distance + Vector3.up * offset.y;


    //    transform.position = Vector3.Lerp(transform.position, targetPosition, rotationSmoothTime);
    //    transform.LookAt(target.position + Vector3.up * offset.y);
    //}

    private void CameraHandling()
    {
        if (target == null || lookInput == null) return;

        Vector2 lookDelta = lookInput.action.ReadValue<Vector2>() * sensitivity;

        currentRotation.x += lookDelta.x;
        currentRotation.y -= lookDelta.y;
        currentRotation.y = Mathf.Clamp(currentRotation.y, minVerticalAngle, maxVerticalAngle);

        Quaternion rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0f);

       
        Vector3 desiredCameraPos = target.position - rotation * Vector3.forward * distance + Vector3.up * offset.y;

        
        Vector3 pivot = target.position + Vector3.up * offset.y;
        Vector3 direction = (desiredCameraPos - pivot).normalized;
        float maxDistance = Vector3.Distance(desiredCameraPos, pivot);
        Vector3 finalPosition = desiredCameraPos;

        if (Physics.Linecast(pivot, desiredCameraPos, out RaycastHit hit))
        {
            finalPosition = pivot + direction * (hit.distance - 0.1f);
        }

        transform.position = Vector3.Lerp(transform.position, finalPosition, rotationSmoothTime);
        transform.LookAt(pivot);
    }

}
