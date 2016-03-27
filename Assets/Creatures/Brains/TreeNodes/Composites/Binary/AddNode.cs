using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class AddNode : BinaryExpNode
{
    public AddNode(BrainTreeNode lhs, BrainTreeNode rhs)
        : base(lhs, rhs)
    {
       
    }

    public override double getValue(double elapsedTime, BodySegment seg)
    {
        return BrainMath.Clamp(LHS.getValue(elapsedTime, seg) + RHS.getValue(elapsedTime, seg), -1, 1);
    }
}