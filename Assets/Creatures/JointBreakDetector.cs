using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class JointBreakDetector : MonoBehaviour
{
    void OnJointBreak(float breakForce)
    {
        Debug.Log("Joint broke: " + gameObject.name + " @ " + breakForce);

        var creature = gameObject.transform.parent.gameObject.GetComponent<Creature>();
        if (creature != null)
        {
            Debug.Log("CREATURE IS DEAD");
        }
    }
}

