using NUnit.Framework;

namespace LinkedList
{
    [TestFixture]
    internal sealed class PropertiesTests
    {
        [Test]
        public void SetFirstNodeWihtNotNullPreviousNodeFieldToEmptyList()
        {
            var list = new MyLinkedList<int>();
            var node = new Node<int>(1);
            var previousNode = new Node<int>(2);
            node.previousNode = previousNode;

            Assert.Throws<ArgumentException>(() => list.AddFirst(node));
        }

        [Test]
        public void SetFirstNodeWihtNotNullPreviousNodeFieldToNotEmptyList()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);

            var node = new Node<int>(1);
            var previousNode = new Node<int>(2);
            node.previousNode = previousNode;

            Assert.Throws<ArgumentException>(() => list.AddFirst(node));
        }

        [Test]
        public void SetLastNodeWihtNotNullPreviousNodeFieldToEmptyList()
        {
            var list = new MyLinkedList<int>();
            var node = new Node<int>(1);
            var nextNode = new Node<int>(2);
            node.previousNode = nextNode;

            Assert.Throws<ArgumentException>(() => list.AddLast(node));
        }

        [Test]
        public void SetLastNodeWihtNotNullNextNodeFieldToNotEmptyList()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);

            var node = new Node<int>(1);
            var nextNode = new Node<int>(2);
            node.nextNode = nextNode;

            Assert.Throws<ArgumentException>(() => list.AddLast(node));
        }
    }
}
