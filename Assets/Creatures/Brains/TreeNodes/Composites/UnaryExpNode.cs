using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class UnaryExpNode : BrainTreeNode
{
    protected BrainTreeNode Operand { get; private set; }

    public UnaryExpNode(BrainTreeNode operand) 
    {
        Operand = operand;
    }

    public override List<BrainTreeNode> getChildren()
    {
        return new List<BrainTreeNode>{ Operand };
    }
}