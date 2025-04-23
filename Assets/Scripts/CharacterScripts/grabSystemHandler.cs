using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class grabSystemHandler : MonoBehaviour
{
    bool LeftHand=false;
    bool RightHand = false;
    bool Grabbing = false;
    Rigidbody HandRB;
    Rigidbody otherBody;
    FixedJoint joint;
    void Start()
    {
        HandRB = GetComponent<Rigidbody>();
        if(this.gameObject.CompareTag("Hand.L"))
        {
            LeftHand = true;
        }
        if (this.gameObject.CompareTag("Hand.R"))
        {
            RightHand = true;
        }
    }
    void OnGrabLeftPress()
    {
        if (LeftHand)
        {
            Grabbing = true;
        }
    }

    void OnGrabLeftRelease()
    {
        if (LeftHand)
        {
            Grabbing = false;
            DestroyJoints();
        }
    }

    void OnGrabRightPress()
    {
        if (RightHand)
        {
            Grabbing = true;
        }
    }

    void OnGrabRightRelease()
    {
        if (RightHand)
        {
            Grabbing = false;
            DestroyJoints();
        }

    }
    void CreateFixedJoint(Rigidbody obj)
    {
        if(!joint)
        {
            joint = HandRB.gameObject.AddComponent<FixedJoint>();
            joint.autoConfigureConnectedAnchor = true;
            joint.connectedBody = obj;
            joint.breakForce = 2000f;
            joint.breakTorque = 2000f;
            joint.enablePreprocessing = false;
            joint.massScale = 1f;
            joint.connectedMassScale = 1f;

        }
    }

    void DestroyJoints()
    {
        Destroy(HandRB.GetComponent<FixedJoint>());
    }

    private void OnTriggerStay(Collider other)
    {
        if (Grabbing)
        {
            Debug.Log("llegue");
            otherBody = other.GetComponent<Rigidbody>();
            CreateFixedJoint(otherBody);
        }
    }
}
