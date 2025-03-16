using NUnit.Framework;

namespace LinkedList
{
    [TestFixture]
    internal sealed class MethodsTests
    {
        #region Тесты для AddAfter

        [Test]
        public void AddValueAfterNullNode()
        {
            var list = new MyLinkedList<int>();
            Assert.Throws<ArgumentNullException>(() => list.AddAfter(null, 1));
        }

        [Test]
        public void AddNullValueAfterNotNullNode()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            Assert.Throws<ArgumentNullException>(() => list.AddAfter(list.Find(1), null));
        }

        [Test]
        public void AddValueAfterFirstNode()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            list.AddAfter(list.Find(1), 1);
            Assert.That(UtilsForTests.CheckOrder(list, new int[] { 1, 1, 2, 3, 4, 5 }), Is.True);
        }


        [Test]
        public void AddValueAfterLastNode()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            list.AddAfter(list.Find(5), 10);
            Assert.That(UtilsForTests.CheckOrder(list, new int[] { 1, 2, 3, 4, 5, 10 }), Is.True);
        }

        [Test]
        public void AddValueAfterNodeAtTheMiddle()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            list.AddAfter(list.Find(3), 15);
            Assert.That(UtilsForTests.CheckOrder(list, new int[] { 1, 2, 3, 15, 4, 5 }), Is.True);
        }

        #endregion

        #region Тесты для AddBefore

        [Test]
        public void AddValueBeforeNullNode()
        {
            var list = new MyLinkedList<int>();
            Assert.Throws<ArgumentNullException>(() => list.AddBefore(null, 1));
        }

        [Test]
        public void AddNullValueBeforeNotNullNode()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            Assert.Throws<ArgumentNullException>(() => list.AddAfter(list.Find(1), null));
        }

        [Test]
        public void AddValueBeforeFirstNode()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            list.AddBefore(list.Find(1), 1);
            Assert.That(UtilsForTests.CheckOrder(list, new int[] { 1, 1, 2, 3, 4, 5 }), Is.True);
        }

        [Test]
        public void AddValueBeforeLastNode()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            list.AddBefore(list.Find(5), 10);
            Assert.That(UtilsForTests.CheckOrder(list, new int[] { 1, 2, 3, 4, 10, 5 }), Is.True);
        }

        [Test]
        public void AddValueBeforeNodeAtTheMiddle()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            list.AddBefore(list.Find(3), 15);
            Assert.That(UtilsForTests.CheckOrder(list, new int[] { 1, 2, 15, 3, 4, 5 }), Is.True);
        }

        #endregion

        #region Тесты для AddFirst

        [Test]
        public void AddFirstToEmptyList()
        {
            var list = new MyLinkedList<int>();
            var node = new Node<int>(1);

            list.AddFirst(node);
            Assert.That(list.First.Value, Is.EqualTo(1));
            Assert.That(list.Last.Value, Is.EqualTo(1));
        }

        [Test]
        public void AddFirstToListWithOneElem()
        {
            var list = new MyLinkedList<int>();
            var node = new Node<int>(1);
            list.AddFirst(node);

            node = new Node<int>(2);
            list.AddFirst(node);
            Assert.That(list.First.Value, Is.EqualTo(2));
            Assert.That(list.Last.Value, Is.EqualTo(1));
        }

        [Test]
        public void AddFirstToListWithSeveralElems()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);

            var node = new Node<int>(10);
            list.AddFirst(node);
            Assert.That(UtilsForTests.CheckOrder(list, new int[] { 10, 1, 2, 3, 4, 5 }), Is.True);
        }

        #endregion

        #region Тесты для AddLast

        [Test]
        public void AddLastToEmptyList()
        {
            var list = new MyLinkedList<int>();
            var node = new Node<int>(1);

            list.AddLast(node);
            Assert.That(list.First.Value, Is.EqualTo(1));
            Assert.That(list.Last.Value, Is.EqualTo(1));
        }

        [Test]
        public void AddLastToListWithOneElem()
        {
            var list = new MyLinkedList<int>();
            var node = new Node<int>(1);
            list.AddLast(node);

            node = new Node<int>(2);
            list.AddLast(node);
            Assert.That(list.First.Value, Is.EqualTo(1));
            Assert.That(list.Last.Value, Is.EqualTo(2));
        }

        [Test]
        public void AddLastToListWithSeveralElems()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);

            var node = new Node<int>(10);
            list.AddLast(node);
            Assert.That(UtilsForTests.CheckOrder(list, new int[] { 1, 2, 3, 4, 5, 10 }), Is.True);
        }

        #endregion

        #region Тесты для Contains

        [Test]
        public void IsListContainsFirstElem()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            Assert.That(list.Contains(1), Is.True);
        }

        [Test]
        public void IsListContainsLastElem()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            Assert.That(list.Contains(5), Is.True);
        }

        [Test]
        public void IsListContainsElemAtTheMiddle()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            Assert.That(list.Contains(3), Is.True);
        }

        [Test]
        public void IsListContainsNotExistingElem()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            Assert.That(list.Contains(10), Is.False);
        }

        #endregion

        #region Тесты для CopyTo

        [Test]
        public void CopyToNullArray()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            int[] array = null;
            Assert.Throws<ArgumentNullException>(() => list.CopyTo(array, 0));
        }

        [Test]
        public void CopyToArrayFromIncorresctPos()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            int[] array = new int[5];
            Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(array, -1));
        }

        [Test]
        public void CopyToArrayWithNotEnoughLength()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            int[] array = new int[3];
            Assert.Throws<ArgumentException>(() => list.CopyTo(array, 0));
        }

        [Test]
        public void CopyToArray()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);

            int[] array = new int[5];
            list.CopyTo(array, 0);
            var i = 0;
            foreach(var num in list)
                Assert.That(array[i++], Is.EqualTo(num));
        }

        #endregion

        #region Тесты для Clear

        [Test]
        public void Clear()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            list.Clear();
            Assert.That(UtilsForTests.IsEmptyListHasCorrectFields(list), Is.True);
        }

        #endregion

        #region Тесты для Find

        [Test]
        public void FindElemInEmptyList()
        {
            var list = new MyLinkedList<int>();
            Assert.That(list.Find(1), Is.Null);
        }

        [Test]
        public void FindElemAtFirstPos()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            Assert.That(list.Find(1).Value, Is.EqualTo(1));
        }

        [Test]
        public void FindElemAtLastPos()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            Assert.That(list.Find(5).Value, Is.EqualTo(5));
        }

        [Test]
        public void FindElemAtTheMiddle()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            Assert.That(list.Find(3).Value, Is.EqualTo(3));
        }

        [Test]
        public void FindNotExistingElem()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            Assert.That(list.Find(10), Is.Null);
        }

        #endregion

        #region Тесты для FindLast

        [Test]
        public void FindElemFromTheEndInEmptyList()
        {
            var list = new MyLinkedList<int>();
            Assert.That(list.Find(1), Is.Null);
        }

        [Test]
        public void FindElemAtFirstPosFromTheEnd()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            Assert.That(list.Find(1).Value, Is.EqualTo(1));
        }

        [Test]
        public void FindElemAtLastPosFromTheEnd()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            Assert.That(list.Find(5).Value, Is.EqualTo(5));
        }

        [Test]
        public void FindElemAtTheMiddleFromTheEnd()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            Assert.That(list.Find(3).Value, Is.EqualTo(3));
        }

        [Test]
        public void FindNotExistingElemFromTheEnd()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            Assert.That(list.FindLast(10), Is.Null);
        }

        #endregion

        #region Тесты для RemoveFirst

        [Test]
        public void RemoveFistInEmptyList()
        {
            var list = new MyLinkedList<int>();
            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
        }

        [Test]
        public void RemoveFistInListWithOneElem()
        {
            var list = new MyLinkedList<int>();
            list.AddFirst(1);
            list.RemoveFirst();
            Assert.That(UtilsForTests.IsEmptyListHasCorrectFields(list), Is.True);
        }

        [Test]
        public void RemoveFirstInListWithSeveralElem()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            list.RemoveFirst();
            Assert.That(UtilsForTests.CheckOrder(list, new int[] { 2, 3, 4, 5 }), Is.True);
        }

        #endregion

        #region Тесты для RemoveLast

        [Test]
        public void RemoveLastInEmptyList()
        {
            var list = new MyLinkedList<int>();
            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
        }

        [Test]
        public void RemoveLastInListWithOneElem()
        {
            var list = new MyLinkedList<int>();
            list.AddFirst(1);
            list.RemoveLast();
            Assert.That(UtilsForTests.IsEmptyListHasCorrectFields(list), Is.True);
        }

        [Test]
        public void RemoveLastInListWithSeveralElem()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            list.RemoveLast();
            Assert.That(UtilsForTests.CheckOrder(list, new int[] { 1, 2, 3, 4 }), Is.True);
        }

        #endregion

        #region Тесты для Remove

        [Test]
        public void RemoveFromEmptyList() 
        {
            var list = new MyLinkedList<int>();
            Assert.That(list.Remove(1), Is.False);
        }

        [Test]
        public void RemoveFirstElem()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            list.Remove(1);
            Assert.That(UtilsForTests.CheckOrder(list, new int[] { 2, 3, 4, 5 }), Is.True);
        }

        [Test]
        public void RemoveLastElem()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            list.Remove(5);
            Assert.That(UtilsForTests.CheckOrder(list, new int[] { 1, 2, 3, 4 }), Is.True);
        }

        [Test]
        public void RemoveElemAtTheMiddle()
        {
            var list = new MyLinkedList<int>();
            UtilsForTests.FillListNumbersFrom1To5(list);
            list.Remove(3);
            Assert.That(UtilsForTests.CheckOrder(list, new int[] { 1, 2, 4, 5 }), Is.True);
        }

        #endregion
    }
}
