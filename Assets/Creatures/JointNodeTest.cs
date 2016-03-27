using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Util;

/// <summary>
/// A single segment in a creatures body
/// </summary>
public class JointNodeTest : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "btn"))
        {
            BodySegment seg = null;

            BrainTreeNode sin = new SinNode(new RandomNode(), new ConstantNode(2), new ConstantNode(3));
            BrainTreeNode mult = new MultNode(new ConstantNode(.1), new ConstantNode(.3));
            BrainTreeNode root = new AddNode(sin, mult);
            JointBrainTree tree = new JointBrainTree(root);
            Debug.Log(tree.getTreeValue(4, seg));
        }

        if (GUI.Button(new Rect(100, 0, 100, 100), "btn2"))
        {
            JointBrainTree tree = BrainTreeGenerator.generateRandomBrainTree();
            Debug.Log(tree.getTreeValue(4, null));
        }
    }
}
