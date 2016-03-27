using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class TernaryExpNode : BrainTreeNode
{
    protected BrainTreeNode Op1 { get; private set; }
    protected BrainTreeNode Op2 { get; private set; }
    protected BrainTreeNode Op3 { get; private set; }

    public TernaryExpNode(BrainTreeNode op1, BrainTreeNode op2, BrainTreeNode op3)
    {
        Op1 = op1;
        Op2 = op2;
        Op3 = op3;
    }

    public override List<BrainTreeNode> getChildren()
    {
        return new List<BrainTreeNode> { Op1, Op2, Op3 };
    }
}
