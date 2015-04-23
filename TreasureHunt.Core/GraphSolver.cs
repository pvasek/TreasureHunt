namespace TreasureHunt.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphSolver
    {
        private static void DistanceInternal(Node from, Node to, int[] distances)
        {
            var distance = distances[to.Index] + 1;
            foreach (var node in to.Nodes)
            {
                var nodeDistance = distances[node.Index];
                if (nodeDistance <= distance)
                {
                    continue;                    
                }
                distances[node.Index] = distance;
                Console.WriteLine("N: {0}, D: {1}", node.Name, distance);
                DistanceInternal(from, node, distances);
                if (node == from)
                {
                    break;
                }
            }
        }

        public static int Distance(Node from, Node to, List<Node> nodes)
        {
            Console.WriteLine("GOAL: from: {0}, to: {1}   ====================", from.Name, to.Name);
            var distances = Enumerable.Repeat(NullDistance, nodes.Count).ToArray();
            distances.Initialize();
            distances[to.Index] = 0;
            DistanceInternal(from, to, distances);
            return distances[from.Index];
        }

        public const int NullDistance = Int32.MaxValue;
    }
}