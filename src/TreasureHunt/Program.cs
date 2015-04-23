namespace TreasureHunt
{
    using System;
    using System.Linq;
    using System.Text;

    using TreasureHunt.Core;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input matrix:");
            var input = new StringBuilder();
            var line = Console.ReadLine();
            while (line != String.Empty)
            {
                input.AppendLine(line);
                line = Console.ReadLine();
            }

            var nodes = GraphParser.FromText(input.ToString());
            var start = nodes.First(i => i.Type == NodeType.Start);
            var gold = nodes.First(i => i.Type == NodeType.Gold);
            var platinium = nodes.First(i => i.Type == NodeType.Platinium);
            
            var goldDistance = GraphSolver.Distance(start, gold, nodes);
            var platiniumDistance = GraphSolver.Distance(start, platinium, nodes);

            if (goldDistance < platiniumDistance)
            {
                Console.WriteLine("g{0}", goldDistance);
            }
            else
            {
                Console.WriteLine("p{0}", platiniumDistance);
            }

            Console.WriteLine("Hit <ENTER> to exit");
            Console.ReadLine();
        }
    }
}
