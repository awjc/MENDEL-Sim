using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class RandomNode : BrainTreeNode
{
    public double Value { get; private set; }

    public RandomNode()
    {
        Value = UnityEngine.Random.Range(-1f, 1f);
    }

    public override double getValue(double elapsedTime, BodySegment seg)
    {
        return Value;
    }

    public override List<BrainTreeNode> getChildren()
    {
        return new List<BrainTreeNode>();
    }
}

