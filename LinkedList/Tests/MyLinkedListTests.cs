using NUnit.Framework;

namespace LinkedList
{
    [TestFixture]
    internal sealed class MyLinkedListTests
    {
        private bool CheckFirstNode<T>(MyLinkedList<T> list, T value)
        {
            if (list.Count == 1)
                return list.First.Value.GetHashCode() == value.GetHashCode() && list.First.nextNode == null && list.First.previousNode == null;
            else
                return list.First.Value.GetHashCode() == value.GetHashCode() && list.First.nextNode != null && list.First.previousNode == null;
        }

        private bool CheckLastNode<T>(MyLinkedList<T> list, T value)
        {
            if (list.Count == 1)
                return list.Last.Value.GetHashCode() == value.GetHashCode() && list.Last.nextNode == null && list.Last.previousNode == null;
            else
                return list.Last.Value.GetHashCode() == value.GetHashCode() && list.Last.previousNode != null && list.Last.nextNode == null;
        }

        private void FillListNumbersFrom1To5(MyLinkedList<int> list)
        {
            for (int i = 1; i <= 5; i++)
                list.AddFirst(i);
        }

        private bool CompareTwoNodes<T>(Node<T> firstNode, Node<T> secondNode)
        {
            return firstNode.Value.GetHashCode() == secondNode.Value.GetHashCode() &&
                   firstNode.nextNode == secondNode.nextNode &&
                   firstNode.previousNode == firstNode.previousNode;
        }
 
        [Test]
        public void AddFirst()
        {
            var list = new MyLinkedList<int>();
            var node = new Node<int>(1);

            list.AddFirst(node);
            Assert.That(CheckFirstNode<int>(list, 1), Is.EqualTo(true));

            node = new Node<int>(2);
            list.AddFirst(node);
            Assert.That(CheckFirstNode<int>(list, 2), Is.EqualTo(true));
        }

        [Test]
        public void AddLast()
        {
            var list = new MyLinkedList<int>();
            var node = new Node<int>(1);

            list.AddLast(node);
            Assert.That(CheckLastNode<int>(list, 1), Is.EqualTo(true));

            node = new Node<int>(2);
            list.AddLast(node);
            Assert.That(CheckLastNode<int>(list, 2), Is.EqualTo(true));
        }

        [Test]
        public void Contains()
        {
            var list = new MyLinkedList<int>();
            FillListNumbersFrom1To5(list);

            Assert.That(list.Contains(5), Is.EqualTo(true));
            Assert.That(list.Contains(1), Is.EqualTo(true));
            Assert.That(list.Contains(3), Is.EqualTo(true));
            Assert.That(list.Contains(10), Is.EqualTo(false));
        }

        [Test]
        public void Clear()
        {
            var list = new MyLinkedList<int>();
            FillListNumbersFrom1To5(list);

            list.Clear();
            Assert.That(list.Count, Is.EqualTo(0));
            Assert.That(list.First, Is.EqualTo(null));
            Assert.That(list.Last, Is.EqualTo(null));
        }

        [Test]
        public void Find()
        {
            var list = new MyLinkedList<int>();
            Assert.That(list.Find(1), Is.EqualTo(null));

            FillListNumbersFrom1To5(list);
            Assert.That(list.Find(1).Value, Is.EqualTo(1));
            Assert.That(list.Find(5).Value, Is.EqualTo(5));
            Assert.That(list.Find(3).Value, Is.EqualTo(3));
            Assert.That(list.Find(10), Is.EqualTo(null));
        }

        [Test]
        public void RemoveFirst()
        {

        }
    }
}
