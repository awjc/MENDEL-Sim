using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class NegateNode : UnaryExpNode
{
    public NegateNode(BrainTreeNode operand)
        : base(operand)
    {
        
    }

    public override double getValue(double elapsedTime, BodySegment seg)
    {
        return -Operand.getValue(elapsedTime, seg);
    }
}