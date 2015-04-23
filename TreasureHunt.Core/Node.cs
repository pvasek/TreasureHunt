namespace TreasureHunt.Core
{
    using System;
    using System.Collections.Generic;

    public class Node
    {
        public Node()
        {
            Nodes = new List<Node>();
        }

        public NodeType Type { get; set; }
        public List<Node> Nodes { get; set; }

        public string Name { get; set; }
        public int Index { get; set; }
    }
}