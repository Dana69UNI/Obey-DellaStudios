using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabScript : MonoBehaviour
{
    [field: Header("SpringJoint AntebrazoDerecho")]
    [field: SerializeField] public SpringJoint jointR { get; private set; }

    [field: Header("SpringJoint AntebrazoIzquierdo")]
    [field: SerializeField] public SpringJoint jointL { get; private set; }

    void OnGrabLeftPress()
    {
        if(jointL != null)
        {
            //Debug.Log("ando agarrando");
            jointL.spring = 4;
        }
    }

    void OnGrabLeftRelease()
    {
        if (jointL != null)
        {
            jointL.spring = 0;
        }

    }

    void OnGrabRightPress()
    {
        if (jointR != null)
        {
            //Debug.Log("ando agarrando");
            jointR.spring = 4;
        }
    }

    void OnGrabRightRelease()
    {
        if (jointR != null)
        {
            jointR.spring = 0;
        }

    }

}
