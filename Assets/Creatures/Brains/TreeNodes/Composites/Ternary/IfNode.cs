using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class IfNode : TernaryExpNode
{
    public IfNode(BrainTreeNode condition, BrainTreeNode ifNegative, BrainTreeNode ifPositive) 
        : base(condition, ifNegative, ifPositive)
    {
        
    }

    public override double getValue(double elapsedTime, BodySegment seg)
    {
        return Op1.getValue(elapsedTime, seg) < 0 ?
                    Op2.getValue(elapsedTime, seg) :
                    Op3.getValue(elapsedTime, seg);
    }
}