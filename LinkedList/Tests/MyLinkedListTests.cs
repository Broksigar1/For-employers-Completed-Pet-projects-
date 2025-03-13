using NUnit.Framework;

namespace LinkedList
{
    [TestFixture]
    internal sealed class MyLinkedListTests
    {
        private bool IsEmptyListHasCorrectFields<T>(MyLinkedList<T> list) => list.Count == 0 && list.First == null && list.Last == null;

        private bool CheckOrder<T>(MyLinkedList<T> list, T[] expectedOrder)
        {
            var currentNode = list.First;

            var i = 0;
            while (currentNode != null && i < expectedOrder.Length)
            {
                if (currentNode.Value.GetHashCode() != expectedOrder[i].GetHashCode())
                    return false;
                currentNode = currentNode.nextNode;
                i++;
            }
            if (i != expectedOrder.Length || currentNode != null) return false;

            i--;
            currentNode = list.Last;
            while (currentNode != null && i >= 0)
            {
                if (currentNode.Value.GetHashCode() != expectedOrder[i].GetHashCode())
                    return false;
                currentNode = currentNode.previousNode;
                i--;
            }
            if (i != -1 || currentNode != null) return false;

            return true;
        }

        private void FillListNumbersFrom1To5(MyLinkedList<int> list)
        {
            for (int i = 1; i <= 5; i++)
                list.AddLast(i);
        }

        #region Тесты на конструкторы

        [Test] // Нужен ли вообще тест на конструктор?
        public void CreateListFromSequence()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> sequence = arr.Select(num => num); // А как-то по другому можно?

            var list = new MyLinkedList<int>(sequence);
            var i = 1;
            foreach(var num in list)
            {
                Assert.That(num, Is.EqualTo(i));
                i++;
            }
        }

        #endregion

        #region Тесты на свойства

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
            FillListNumbersFrom1To5(list);

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
            node.nextNode = nextNode;

            Assert.Throws<ArgumentException>(() => list.AddLast(node));
        }

        [Test]
        public void SetLastNodeWihtNotNullPreviousNodeFieldToNotEmptyList()
        {
            var list = new MyLinkedList<int>();
            FillListNumbersFrom1To5(list);

            var node = new Node<int>(1);
            var nextNode = new Node<int>(2);
            node.nextNode = nextNode;

            Assert.Throws<ArgumentException>(() => list.AddLast(node));
        }


        #endregion

        #region Тесты на методы

        [Test]
        public void AddFirst()
        {
            var list = new MyLinkedList<int>();
            var node = new Node<int>(1);

            list.AddFirst(node);
            Assert.That(list.First.Value, Is.EqualTo(1));
            Assert.That(list.Last.Value, Is.EqualTo(1));

            node = new Node<int>(2);
            list.AddFirst(node);
            Assert.That(list.First.Value, Is.EqualTo(2));
            Assert.That(list.Last.Value, Is.EqualTo(1));

            node = new Node<int>(3);
            list.AddFirst(node);
            foreach (var num in list)
                Assert.That(CheckOrder(list, new int[] { 3, 2, 1 }), Is.True);
        }

        [Test]
        public void AddLast()
        {
            var list = new MyLinkedList<int>();
            var node = new Node<int>(1);

            list.AddLast(node);
            Assert.That(list.First.Value, Is.EqualTo(1));
            Assert.That(list.Last.Value, Is.EqualTo(1));

            node = new Node<int>(2);
            list.AddLast(node);
            Assert.That(list.First.Value, Is.EqualTo(1));
            Assert.That(list.Last.Value, Is.EqualTo(2));

            node = new Node<int>(3);
            list.AddLast(node);
            foreach (var num in list)
                Assert.That(CheckOrder(list, new int[] { 1, 2, 3 }), Is.True);
        }

        [Test]
        public void Contains()
        {
            var list = new MyLinkedList<int>();
            FillListNumbersFrom1To5(list);

            Assert.That(list.Contains(5), Is.True);
            Assert.That(list.Contains(1), Is.True);
            Assert.That(list.Contains(3), Is.True);
            Assert.That(list.Contains(10), Is.False);
        }

        [Test]
        public void CopyTo()
        {
            var list = new MyLinkedList<int>();
            FillListNumbersFrom1To5(list);

            int[] array = null;
            Assert.Throws<ArgumentNullException>(() => list.CopyTo(array, 0));
            array = new int[5];
            Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(array, -1));
            array = new int[3];
            Assert.Throws<ArgumentException>(() => list.CopyTo(array, 0));

            array = new int[5];
            list.CopyTo(array, 0);
            var i = 0;
            foreach(var num in list)
                Assert.That(array[i++], Is.EqualTo(num));

        }

        [Test]
        public void Clear()
        {
            var list = new MyLinkedList<int>();
            FillListNumbersFrom1To5(list);

            list.Clear();
            Assert.That(IsEmptyListHasCorrectFields(list), Is.True);
        }

        [Test]
        public void Find()
        {
            var list = new MyLinkedList<int>();
            Assert.That(list.Find(1), Is.Null);

            FillListNumbersFrom1To5(list);
            Assert.That(list.Find(1).Value, Is.EqualTo(1));
            Assert.That(list.Find(5).Value, Is.EqualTo(5));
            Assert.That(list.Find(3).Value, Is.EqualTo(3));
            Assert.That(list.Find(10), Is.Null);
        }

        [Test]
        public void RemoveFirst()
        {
            var list = new MyLinkedList<int>();
            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());

            list.AddFirst(1);
            list.RemoveFirst();
            Assert.That(IsEmptyListHasCorrectFields(list), Is.True);

            FillListNumbersFrom1To5(list);
            list.RemoveFirst();
            Assert.That(CheckOrder(list, new int[] { 2, 3, 4, 5 }), Is.True);
        }

        [Test]
        public void RemoveLast()
        {
            var list = new MyLinkedList<int>();
            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());

            list.AddFirst(1);
            list.RemoveLast();
            Assert.That(IsEmptyListHasCorrectFields(list), Is.True);

            FillListNumbersFrom1To5(list);
            list.RemoveLast();
            Assert.That(CheckOrder(list, new int[] { 1, 2, 3, 4 }), Is.True);
        }

        [Test]
        public void Remove()
        {
            var list = new MyLinkedList<int>();
            Assert.That(list.Remove(1), Is.False);


            FillListNumbersFrom1To5(list);
            list.Remove(1);
            Assert.That(CheckOrder(list, new int[] { 2, 3, 4, 5 }), Is.True);

            list.AddFirst(1);
            list.Remove(5);
            Assert.That(CheckOrder(list, new int[] { 1, 2, 3, 4 }), Is.True);

            list.AddLast(5);
            list.Remove(3);
            Assert.That(CheckOrder(list, new int[] { 1, 2, 4, 5 }), Is.True);
        }

        #endregion 
    }
}
