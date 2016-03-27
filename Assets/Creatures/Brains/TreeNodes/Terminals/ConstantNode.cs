using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ConstantNode : BrainTreeNode
{
    public double Value { get; private set; }

    public ConstantNode(double val)
    {
        Value = val;
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

