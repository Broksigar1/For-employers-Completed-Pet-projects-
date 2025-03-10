using NUnit.Framework;

namespace LinkedList
{
    [TestFixture]
    internal sealed class MyLinkedListTests
    {
        private bool CheckFirstNode<T>(MyLinkedList<T> list, T value)
        {
            if (list.Count == 1)
                return list.First.Value.GetHashCode() == value.GetHashCode() && list.First.nextNode == list.First.previousNode == null;
            else
                return list.First.Value.GetHashCode() == value.GetHashCode() && list.First.nextNode != null && list.First.previousNode == null;
        }

        private bool CheckLastNode<T>(MyLinkedList<T> list, T value)
        {
            if (list.Count == 1)
                return list.Last.Value.GetHashCode() == value.GetHashCode() && list.Last.nextNode == list.Last.previousNode == null;
            else
                return list.Last.Value.GetHashCode() == value.GetHashCode() && list.Last.previousNode != null && list.Last.nextNode == null;
        }
 
        [Test]
        public void AddFirst()
        {
            var list = new MyLinkedList<int>();
            var node = new Node<int>(1);
            list.AddFirst(node);
            Assert.That(CheckFirstNode<int>(list, 2), Is.EqualTo(true));
        }
    }
}
