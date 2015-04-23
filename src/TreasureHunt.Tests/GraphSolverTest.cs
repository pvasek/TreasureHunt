namespace TreasureHunt.Tests
{
    using System.Linq;

    using NUnit.Framework;

    using TreasureHunt.Core;

    [TestFixture]
    public class GraphSolverTest
    {
        [Test]
        public void ShouldParseSimpleGraph1()
        {
            var input = @"  e g e
                            s e e
                            e e p";

            // this is definitelly not a good practive for unit test, use another "unit" that can is not needed, just to make it faster :)
            var nodes = GraphParser.FromText(input);
            var start = nodes.First(i => i.Type == NodeType.Start);
            var gold = nodes.First(i => i.Type == NodeType.Gold);
            var platinium = nodes.First(i => i.Type == NodeType.Platinium);

            Assert.AreEqual(1, GraphSolver.Distance(start, gold, nodes));
            Assert.AreEqual(2, GraphSolver.Distance(start, platinium, nodes));
        }

        [Test]
        public void ShouldParseSimpleGraph2()
        {
            var input = @"	e e p
	                        s o e
	                        e o g";

            var nodes = GraphParser.FromText(input);
            var start = nodes.First(i => i.Type == NodeType.Start);
            var gold = nodes.First(i => i.Type == NodeType.Gold);
            var platinium = nodes.First(i => i.Type == NodeType.Platinium);

            Assert.AreEqual(3, GraphSolver.Distance(start, gold, nodes));
            Assert.AreEqual(2, GraphSolver.Distance(start, platinium, nodes));
        }

        [Test]
        public void ShouldParseSimpleGraph3()
        {
            var input = @"	s e e o
	                        e o o e
	                        o o e o
	                        p o e g";

            var nodes = GraphParser.FromText(input);
            var start = nodes.First(i => i.Type == NodeType.Start);
            var gold = nodes.First(i => i.Type == NodeType.Gold);
            var platinium = nodes.First(i => i.Type == NodeType.Platinium);

            Assert.AreEqual(5, GraphSolver.Distance(start, gold, nodes));
            Assert.AreEqual(GraphSolver.NullDistance, GraphSolver.Distance(start, platinium, nodes));
        }
    }
}