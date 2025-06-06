using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamaraColl : MonoBehaviour
{
    public Transform desiredTrns;
    public Transform playerTransform;
    public LayerMask wallLayers;
    private Vector3 desiredPosition;

    private void Start()
    {
        desiredPosition = desiredTrns.position;

    }
    void Update()
    {
        RaycastHit hit;
        Vector3 targetPosition;

        if (Physics.Raycast(desiredPosition, playerTransform.position - desiredPosition, out hit, (playerTransform.position - desiredPosition).magnitude, wallLayers))
        {
            targetPosition = (hit.point - playerTransform.position) * 0.8f + playerTransform.position;
            /* 
               Note that I move the camera to 80% of the distance
               to the point where an obstruction has been found
               to help keep the sides of the frustrum from still clipping through the wall
            */
        }
        else
        {
            targetPosition = desiredPosition;
        }

        gameObject.transform.position = desiredPosition;
        
    }
}
