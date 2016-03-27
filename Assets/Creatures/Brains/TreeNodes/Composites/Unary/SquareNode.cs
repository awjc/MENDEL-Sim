using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SquareNode : UnaryExpNode
{
    public SquareNode(BrainTreeNode operand)
        : base(operand)
    {
        
    }

    public override double getValue(double elapsedTime, BodySegment seg)
    {
        return Math.Pow(Operand.getValue(elapsedTime, seg), 2);
    }
}