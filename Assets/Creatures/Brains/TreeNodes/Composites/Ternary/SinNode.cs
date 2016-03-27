using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class SinNode : TernaryExpNode
{
    public SinNode(BrainTreeNode phaseOffset, BrainTreeNode scaleParam, BrainTreeNode input) 
        : base(phaseOffset, scaleParam, input)
    {
        
    }

    public override double getValue(double elapsedTime, BodySegment seg)
    {
        return Math.Sin(Op1.getValue(elapsedTime, seg) +
                       (Op2.getValue(elapsedTime, seg) * elapsedTime) +
                       (2 * Mathf.PI * Op3.getValue(elapsedTime, seg)));
    }
}