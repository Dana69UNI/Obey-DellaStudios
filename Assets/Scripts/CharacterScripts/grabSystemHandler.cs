using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class grabSystemHandler : MonoBehaviour
{
    bool LeftHand=false;
    bool RightHand = false;
   public bool Grabbing = false;
    public bool objGrab = false;
    Rigidbody HandRB;
    GameObject otherGObj;
    Rigidbody otherBody;
    FixedJoint joint;
    gorroHandler GorroExtScript = null;
    public gorroHandler GorroScript;
    private int gorroExtIndex;
    private int gorroIndex;
    private bool canChangeHat = true;
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
    void CreateFixedJoint(Rigidbody obj, GameObject otherGobj)
    {
        if(otherGObj.layer != LayerMask.NameToLayer("ExcludeCollisionChar"))
        {
            if(otherGObj.layer == LayerMask.NameToLayer("Gorro"))
            {
                if(canChangeHat)
                {
                    GorroExtScript = otherGObj.GetComponent<gorroHandler>();
                    gorroExtIndex = GorroExtScript.getHatIndex();
                    gorroIndex = GorroScript.getHatIndex();
                    GorroExtScript.changeHat(gorroIndex);
                    GorroScript.changeHat(gorroExtIndex);
                    canChangeHat = false;
                    StartCoroutine(GorroCD());
                }
               
            }
            if (!joint)
            {
                joint = HandRB.gameObject.AddComponent<FixedJoint>();
                joint.autoConfigureConnectedAnchor = true;
                joint.connectedBody = obj;
                joint.breakForce = 2000f;
                joint.breakTorque = 2000f;
                joint.enablePreprocessing = false;
                joint.massScale = 1f;
                joint.connectedMassScale = 1f;
                objGrab = true;
            }
        }
        
    }

    void DestroyJoints()
    {
        Destroy(HandRB.GetComponent<FixedJoint>());
        objGrab = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Grabbing)
        {
            otherGObj = other.gameObject;
            otherBody = other.GetComponent<Rigidbody>();
            CreateFixedJoint(otherBody, otherGObj);
        }
    }

    IEnumerator GorroCD()
    {
        yield return new WaitForSeconds(1.2f);
        canChangeHat = true;

    }
}
