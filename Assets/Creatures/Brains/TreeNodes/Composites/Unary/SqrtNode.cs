using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SqrtNode : UnaryExpNode
{
    public SqrtNode(BrainTreeNode operand)
        : base(operand)
    {
        
    }

    public override double getValue(double elapsedTime, BodySegment seg)
    {
        return Math.Pow(Math.Abs(Operand.getValue(elapsedTime, seg)), 0.5);
    }
}