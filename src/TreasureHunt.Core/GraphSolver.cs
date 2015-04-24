namespace TreasureHunt.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphSolver
    {
        private static void DistanceWalk(Node node, int[] distances)
        {
            var distance = distances[node.Index] + 1;
            foreach (var connectedNode in node.Nodes)
            {
                var nodeDistance = distances[connectedNode.Index];
                if (nodeDistance <= distance)
                {
                    continue;                    
                }
                distances[connectedNode.Index] = distance;

                DistanceWalk(connectedNode, distances);
            }
        }

        public static int Distance(Node from, Node to, List<Node> nodes)
        {
            var distances = Enumerable.Repeat(NullDistance, nodes.Count).ToArray();
            distances.Initialize();
            distances[to.Index] = 0;
            DistanceWalk(to, distances);
            return distances[from.Index];
        }

        public const int NullDistance = Int32.MaxValue;
    }
}