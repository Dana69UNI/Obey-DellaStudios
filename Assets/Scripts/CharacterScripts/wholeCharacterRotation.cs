using UnityEngine;
using UnityEngine.InputSystem;

public class WholeCharacterRotationInputBased : MonoBehaviour
{
    public InputActionReference moveInput;

    public Camera playerCamera;

    [Header("Rotación")]
    public float rotationSpeed = 5f;
    public bool onlyYRotation = true;

    void FixedUpdate()
    {
        Vector2 input = moveInput.action.ReadValue<Vector2>();
        Vector3 moveDir = input.x * GetCameraRight() + input.y * GetCameraForward();

        if (onlyYRotation)
            moveDir.y = 0;

        if (moveDir.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDir.normalized);

            if (onlyYRotation)
                targetRotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private Vector3 GetCameraForward()
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight()
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
}
