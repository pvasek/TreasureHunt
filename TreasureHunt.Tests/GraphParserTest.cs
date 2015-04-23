namespace TreasureHunt.Tests
{
    using NUnit.Framework;

    using TreasureHunt.Core;

    [TestFixture]
    public class GraphParserTest
    {
        [Test]
        public void ShouldParseSimpleGraph1()
        {
            var input = @"  e g e
                            s e e
                            e e p";

            var result = GraphParser.FromText(input);
            Assert.AreEqual(9, result.Count);

            Assert.AreEqual(3, result[0].Nodes.Count);
            Assert.AreEqual(5, result[1].Nodes.Count);
            Assert.AreEqual(3, result[2].Nodes.Count);

            Assert.AreEqual(5, result[3].Nodes.Count);
            Assert.AreEqual(8, result[4].Nodes.Count);
            Assert.AreEqual(5, result[5].Nodes.Count);

            Assert.AreEqual(3, result[6].Nodes.Count);
            Assert.AreEqual(5, result[7].Nodes.Count);
            Assert.AreEqual(3, result[8].Nodes.Count);

            var middleNodes = result[4].Nodes;
            Assert.AreEqual(result[0], middleNodes[0]);
            Assert.AreEqual(result[3], middleNodes[1]);
            Assert.AreEqual(result[6], middleNodes[2]);
            Assert.AreEqual(result[1], middleNodes[3]);
            Assert.AreEqual(result[7], middleNodes[4]);
            Assert.AreEqual(result[2], middleNodes[5]);
            Assert.AreEqual(result[5], middleNodes[6]);
            Assert.AreEqual(result[8], middleNodes[7]);
        }

        [Test]
        public void ShouldParseSimpleGraph2()
        {
            var input = @"	e e p
	                        s o e
	                        e o g";

            var result = GraphParser.FromText(input);
            Assert.AreEqual(7, result.Count);
            Assert.AreEqual(1, result[5].Nodes.Count);
        }
    }
}
