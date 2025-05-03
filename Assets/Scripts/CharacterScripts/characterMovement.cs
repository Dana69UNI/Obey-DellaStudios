using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class characterMovement : MonoBehaviour
{
   
    public UserInput userInput;
    private Rigidbody rb;
    public float movementForce = 1f;
    public float maxSpeed = 6f;
    public float JumpForce = 5f;
    public float treparForce = 10f;
    public InputActionReference move;
    private Vector3 inputMovement = Vector3.zero;
    private Vector3 LastinputMovement;
    float stopMult = 0.6f;
    public Camera playerCamera;
    bool isGrounded;
    bool isHangingFromLedge;
    float distToGround;
    float contadorTrepar = 0f;
    float hangingThreshold = 0.5f;
    float hangingTimer = 0f;
    private Vector3 lastHangingCheckPos;

    [field: Header("GroundedRaycast Right")]
    [field: SerializeField] public Transform groundedRayRight { get; private set; }


    [field: Header("GroundedRaycast Left")]
    [field: SerializeField] public Transform groundedRayLeft { get; private set; }

    [field: Header("LedgeRaycast")]
    [field: SerializeField] public Transform ledgeRay { get; private set; }

    [field: Header("GrabSystemLeft")]
    [field: SerializeField] public grabSystemHandler gSTLeft { get; private set; }

    [field: Header("GrabSystemRight")]
    [field: SerializeField] public grabSystemHandler gSTRight { get; private set; }

    [field: Header("TibiaLeftRB")]
    [field: SerializeField] public Rigidbody tibiaL { get; private set; }

    [field: Header("TibiaRightRB")]
    [field: SerializeField] public Rigidbody tibiaR { get; private set; }



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
        RaycastHit hitL;
        RaycastHit hitR;
        Physics.Raycast(groundedRayLeft.transform.position, Vector3.down, out hitL);
        Physics.Raycast(groundedRayRight.transform.position, Vector3.down, out hitR);

        if(hitL.distance > 0.3f && hitR.distance > 0.3f)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
    }

    private void OnJump()
    {
        if(isGrounded)
        {
            rb.AddForce(JumpForce * Vector3.up, ForceMode.Impulse);
       
        }
    }

    private void OnTrepar()
    {
        isHangingCheck();
       
        
    }

    private IEnumerator Trepar()
    {
        while (contadorTrepar < 1f)
        {
            Debug.Log("llego");
            tibiaL.AddForce(treparForce * Time.deltaTime * Vector3.up, ForceMode.Impulse);
            tibiaR.AddForce(treparForce * Time.deltaTime * Vector3.up, ForceMode.Impulse);
            contadorTrepar += Time.deltaTime;
            yield return null;
        }
        isHangingFromLedge = false;
        contadorTrepar = 0f;
    }

    private void isHangingCheck()
    {
        if (!isGrounded && gSTLeft.objGrab && gSTRight.objGrab)
        {
            
            StartCoroutine(hangingDelay());
        }
    }

    private IEnumerator hangingDelay()
    {
        lastHangingCheckPos = transform.position;
        while (hangingTimer < 1.4f)
        {
            float dist = Vector3.Distance(transform.position, lastHangingCheckPos);
            if (dist > hangingThreshold)
            {
                break;
            }
            else
            {
                hangingTimer += Time.deltaTime;
                yield return null;
            }
           
        }
        if(hangingTimer >=1.4f)
        {
            
            isHangingFromLedge = true;
            StartCoroutine(Trepar());
            hangingTimer = 0f;
            yield return null;
        }
        else
        {
            isHangingFromLedge = false;
            hangingTimer = 0f;
        }
        
    }
}
