using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class BrainTreeGenerator
{
    private static List<string> terminals = new List<string>
    {
        "ConstantNode",
        "JointNode",
        "RandomNode"
    };

    private static List<string> composites = new List<string>
    {
        "NegateNode",
        "SqrtNode",
        "SquareNode",

        "AddNode",
        "MultNode",
        "SubtractNode",

        "IfNode",
        "SinNode",
        "SinNode",
        "SinNode",
        "SinNode",
        "SinNode",
        "SinNode",
        "SinNode",
        "SinNode"
    };

    public static JointBrainTree generateRandomBrainTree()
    {
        BrainTreeNode root = generateRandomNode(new System.Random(), 0);

        JointBrainTree tree = new JointBrainTree(root);
        return tree;
    }

    public static BrainTreeNode generateRandomNode(System.Random r, double terminalProb)
    {
        double dice = r.NextDouble();
        if (dice <= terminalProb)
        {
            string chosen = terminals[r.Next(terminals.Count)];
            switch (chosen)
            {
                case "ConstantNode":
                    return new ConstantNode(r.NextDouble() * 2 - 1);
                case "JointNode":
                    return new JointNode(r.Next(2));
                case "RandomNode":
                    return new RandomNode();

                default:
                    return null;
            }
        }
        else
        {
            string chosen = composites[r.Next(composites.Count)];
            double newProb = terminalProb + 0.1;
            switch (chosen)
            {
                case "NegateNode":
                    return new NegateNode(generateRandomNode(r, newProb));
                case "SqrtNode":
                    return new SqrtNode(generateRandomNode(r, newProb));
                case "SquareNode":
                    return new SquareNode(generateRandomNode(r, newProb));

                case "AddNode":
                    return new AddNode(generateRandomNode(r, newProb), 
				                       generateRandomNode(r, newProb));
                case "SubtractNode":
                    return new SubtractNode(generateRandomNode(r, newProb), 
				                            generateRandomNode(r, newProb));
                case "MultNode":
                    return new MultNode(generateRandomNode(r, newProb), 
				                        generateRandomNode(r, newProb));

                case "SinNode":
                    return new SinNode(generateRandomNode(r, newProb), 
					                   generateRandomNode(r, newProb), 
					                   generateRandomNode(r, newProb));
                case "IfNode":
                    return new IfNode(generateRandomNode(r, newProb), 
				                  	  generateRandomNode(r, newProb), 
				                  	  generateRandomNode(r, newProb));

                default:
                    return null;
            }
        }
    }
}
