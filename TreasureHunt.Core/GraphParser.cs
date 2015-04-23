namespace TreasureHunt.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;

    public class GraphParser
    {
        private static readonly Dictionary<char, NodeType?> charNodeTypeMap = new Dictionary<char, NodeType?>
            {
                {'s', NodeType.Start},
                {'e', NodeType.Empty},
                {'g', NodeType.Gold},
                {'p', NodeType.Platinium},
                {'o', null}
            };

        private static void AddIfNotNull(Node primary, Node secondary)
        {
            if (secondary != null)
            {
                primary.Nodes.Add(secondary);
            }
        }

        public static List<Node> FromText(string text)
        {
            var rows = new List<List<Node>>();
            StringReader sr = new StringReader(text);
            var line = sr.ReadLine();
            var cols = -1;
            var lineIndex = 0;
            while (line != null)
            {
                line = line.Trim().Replace(" ", "");
                var nodes = line.Select((c, i) => CreateNode(c, i, lineIndex)).ToList();
                if (cols != -1 && cols != nodes.Count)
                {
                    throw new ArgumentException("There has to be the same number of columns");
                }
                cols = nodes.Count;
                rows.Add(nodes);
                line = sr.ReadLine();
                lineIndex++;
            }

            var emptyRow = Enumerable
                .Range(0, cols)
                .Select(i => (Node)null)
                .ToList();

            for (var i = 0; i < rows.Count; i++)
            {
                var previousRow = i > 0 ? rows[i - 1] : emptyRow;
                var currentRow = rows[i];
                var nextRow = i < rows.Count - 1 ? rows[i + 1] : emptyRow;
                for (var j = 0; j < currentRow.Count; j++)
                {
                    var currentNode = currentRow[j];
                    if (currentNode == null)
                    {
                        continue;
                    }

                    if (j > 0)
                    {
                        var previousColIndex = j - 1;                        
                        AddIfNotNull(currentNode, previousRow[previousColIndex]);
                        AddIfNotNull(currentNode, currentRow[previousColIndex]);
                        AddIfNotNull(currentNode, nextRow[previousColIndex]);
                    }
                    
                    AddIfNotNull(currentNode, previousRow[j]);
                    AddIfNotNull(currentNode, nextRow[j]); 
                    
                    if (j < currentRow.Count - 1)
                    {
                        var nextColIndex = j + 1;
                        AddIfNotNull(currentNode, previousRow[nextColIndex]);
                        AddIfNotNull(currentNode, currentRow[nextColIndex]);
                        AddIfNotNull(currentNode, nextRow[nextColIndex]);
                    }
                }
            }

            var result = rows
                .SelectMany(i => i)
                .Where(i => i != null)
                .ToList();

            var index = 0;
            foreach (var node in result)
            {
                node.Index = index++;
            }
            return result;
        }

        public static Node CreateNode(char character, int col, int row)
        {
            NodeType? nodeType;
            if (!charNodeTypeMap.TryGetValue(character, out nodeType))
            {
                throw new ArgumentException(string.Format("Character '{0}' is not allowed'", character));
            }
            return nodeType == null ? null : new Node { Type = nodeType.Value, Name = String.Format("{0} {1}", col, row) };
        }
    }
}
