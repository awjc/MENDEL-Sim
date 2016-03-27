using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class JointNode : BrainTreeNode
{
    public int Axis { get; private set; }

    public JointNode(int axis)
    {
        Axis = axis;
    }

    public override double getValue(double elapsedTime, BodySegment seg)
    {
        if (seg == null || seg.myJointMotor == null) return 0;

        Vector3 rot = seg.myJointMotor.joint.gameObject.transform.rotation.eulerAngles;

        float val = 0;
        if (Axis == 0)
        {
            val = rot.x;
        }
        if (Axis == 0)
        {
            val = rot.y;
        }

        return BrainMath.Clamp(((val + 90) % 360) / 90f - 1, -1, 1);
    }

    public Quaternion getJointRotation(ConfigurableJoint joint)
    {
        return (Quaternion.FromToRotation(joint.axis, joint.connectedBody.transform.rotation.eulerAngles));
    }

    public override List<BrainTreeNode> getChildren()
    {
        return new List<BrainTreeNode>();
    }
}

