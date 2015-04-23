namespace TreasureHunt.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GraphSolver
    {
        private static void DistanceWalk(Node from, Node to, int[] distances)
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

                DistanceWalk(from, node, distances);
                if (node == from)
                {
                    break;
                }
            }
        }

        public static int Distance(Node from, Node to, List<Node> nodes)
        {
            var distances = Enumerable.Repeat(NullDistance, nodes.Count).ToArray();
            distances.Initialize();
            distances[to.Index] = 0;
            DistanceWalk(from, to, distances);
            return distances[from.Index];
        }

        public const int NullDistance = Int32.MaxValue;
    }
}