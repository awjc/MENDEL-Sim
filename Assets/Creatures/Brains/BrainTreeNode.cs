using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class BrainTreeNode
{
    public abstract double getValue(double elapsedTime, BodySegment seg);

    public abstract List<BrainTreeNode> getChildren();

    public BrainTreeNode()
    {
        
    }
}
