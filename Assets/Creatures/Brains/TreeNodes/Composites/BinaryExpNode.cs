using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class BinaryExpNode : BrainTreeNode
{
    protected BrainTreeNode LHS { get; private set; }
    protected BrainTreeNode RHS { get; private set; }

    public BinaryExpNode(BrainTreeNode lhs, BrainTreeNode rhs)
    {
        LHS = lhs;
        RHS = rhs;
    }

    public override List<BrainTreeNode> getChildren()
    {
        return new List<BrainTreeNode> { LHS, RHS };
    }
}