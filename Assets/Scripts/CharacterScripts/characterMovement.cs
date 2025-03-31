using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterMovement : MonoBehaviour
{
    public UserInput userInput;
    private Rigidbody rb;
    private float movementForce = 1f;
    private float maxSpeed = 5f;
    private Vector3 inputMovement = Vector3.zero;
    private Camera playerCamera;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        userInput = new UserInput();
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
      
        //inputMovement += value.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        //inputMovement += value.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;
        //rb.AddForce(inputMovement, ForceMode.Impulse);
        //inputMovement = Vector3.zero;
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
