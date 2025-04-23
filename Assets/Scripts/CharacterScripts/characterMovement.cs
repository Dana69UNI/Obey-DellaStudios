using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterMovement : MonoBehaviour
{
   
    public UserInput userInput;
    private Rigidbody rb;
    public float movementForce = 1f;
    public float maxSpeed = 6f;
    public InputActionReference move;
    private Vector3 inputMovement = Vector3.zero;
    private Vector3 LastinputMovement;
    float stopMult = 0.6f;
    public Camera playerCamera;
    bool isGrounded;
    float distToGround;

    [field: Header("GroundedRaycast Right")]
    [field: SerializeField] public Transform groundedRayRight { get; private set; }


    [field: Header("GroundedRaycast Left")]
    [field: SerializeField] public Transform groundedRayLeft { get; private set; }


    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        userInput = new UserInput();
    }

    public void OnMovement()
    {
     
        inputMovement += move.action.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        inputMovement += move.action.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;
        if (inputMovement.x > maxSpeed)
        {
            inputMovement.x = maxSpeed;
        }
        if (inputMovement.z > maxSpeed)
        {
            inputMovement.z = maxSpeed;
        }
        if (inputMovement.y > maxSpeed)
        {
            inputMovement.y = maxSpeed;
        }

        rb.AddForce(inputMovement.normalized, ForceMode.Impulse);
        LastinputMovement=inputMovement;
        inputMovement = Vector3.zero;
    }

    private void FixedUpdate()
    {
        OnMovement();
        isGroundedCheck();
    }

    void OnMovementRelease()
    {
        rb.AddForce(-LastinputMovement.normalized * stopMult, ForceMode.Impulse);
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0f;
        return right.normalized;
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0f;
        return forward.normalized;
    }

    private void isGroundedCheck()
    {
        RaycastHit hit;
        Physics.Raycast(groundedRayLeft.transform.position, Vector3.down, out hit);
        Debug.Log(hit.);
    }
}
