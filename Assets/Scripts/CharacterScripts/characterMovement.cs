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
    private float maxSpeed = 6f;
    public InputActionReference move;
    private Vector3 inputMovement = Vector3.zero;
    public Camera playerCamera;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        userInput = new UserInput();
    }

    public void OnMovement()
    {
        Debug.Log("AAAAAA");
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

        rb.AddForce(inputMovement, ForceMode.Impulse);
        inputMovement = Vector3.zero;
    }

    private void FixedUpdate()
    {
        OnMovement();
        
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
}
