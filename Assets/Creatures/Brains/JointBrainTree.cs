using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class JointBrainTree
{
    public BrainTreeNode Root { get; private set; }

    public JointBrainTree(BrainTreeNode root)
    {
        Root = root;
    }

    public double getTreeValue(double elapsedTime, BodySegment seg)
    {
        return Root.getValue(elapsedTime, seg);
    }
}
