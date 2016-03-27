using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class SubtractNode : BinaryExpNode
{
    public SubtractNode(BrainTreeNode lhs, BrainTreeNode rhs)
        : base(lhs, rhs)
    {
        
    }

    public override double getValue(double elapsedTime, BodySegment seg)
    {
        return BrainMath.Clamp(LHS.getValue(elapsedTime, seg) - RHS.getValue(elapsedTime, seg), -1, 1);
    }
}