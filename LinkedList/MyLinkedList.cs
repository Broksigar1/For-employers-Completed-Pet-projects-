﻿using Newtonsoft.Json.Linq;

namespace LinkedList
{
    internal sealed class MyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> first = null;
        private Node<T> last = null;
        private int count = 0;

        #region конструкторы

        public MyLinkedList(IEnumerable<T> sequence)
        {
            foreach (var node in sequence)
                AddLast(node);
        }

        #endregion

        #region Свойства
        public Node<T> First
        {
            get
            {
                return first;
            }
            private set 
            {
                first = value;
            }
        }

        public Node<T> Last
        {
            get
            {
                return last;
            }

            private set
            {
                last = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }

            private set
            {
                count = value;
            }
        }
        #endregion

        #region public методы

        public void AddAfter(Node<T> node, T value)
        {
            var newNode = new Node<T>(value);
            AddAfter(node, newNode);
        }

        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            if (node == null || newNode == null) throw new ArgumentNullException();

            var findedNode = FindNode(node);
            if (findedNode == null || newNode.nextNode != null || newNode.previousNode != null)
                throw new InvalidOperationException();

            newNode.previousNode = findedNode;
            newNode.nextNode = findedNode.nextNode;
            findedNode.nextNode = newNode;
            newNode.nextNode.previousNode = newNode;
        }

        public void AddBefore(Node<T> node, T value)
        {
            var newNode = new Node<T>(value);
            AddBefore(node, newNode);
        }

        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            if (node == null || newNode == null) throw new ArgumentNullException();

            var findedNode = FindLastNode(node);
            if (findedNode == null || newNode.nextNode != null || newNode.previousNode != null)
                throw new InvalidOperationException();

            newNode.nextNode = findedNode;
            newNode.previousNode = findedNode.previousNode;
            findedNode.previousNode = newNode;
            newNode.previousNode.nextNode = newNode;
        }



        public void AddFirst(T value) => AddNodeToFirstOrLastPosition(new Node<T>(value), true);

        public void AddFirst(Node<T> node) => AddNodeToFirstOrLastPosition(node, true);

        public void AddLast(T value) => AddNodeToFirstOrLastPosition(new Node<T>(value), false);

        public void AddLast(Node<T> node) => AddNodeToFirstOrLastPosition(node, false);

        private void AddNodeToFirstOrLastPosition(Node<T> node, bool firstOrLast) // true - First, false - Last
        {
            Count++;
            if ((firstOrLast ? First : Last) != null)
            {
                if (firstOrLast)
                {
                    node.nextNode = First;
                    First = node;
                    node.nextNode.previousNode = node;
                }
                else
                {
                    node.previousNode = Last;
                    Last = node;
                    node.previousNode.nextNode = node;
                }
            }
            else
            {
                First = node;
                Last = node;
            }
        }

        public bool Contains(T value) => Find(value) != null;

        public void CopyTo(T[] array, int startPos)
        {
            if (array == null) throw new ArgumentNullException();
            if (startPos < 0) throw new ArgumentOutOfRangeException();
            if (Count - startPos > array.Length) throw new ArgumentException();

            var currentNode = First;
            var i = 0;
            while (currentNode != null)
            {
                if (i >= startPos)
                    array[i - startPos] = currentNode.Value;
                i++;
                currentNode = currentNode.nextNode;
            }
        }

        public void Clear()
        {
            while (Count > 0)
                RemoveFirst();
        }

        public Node<T> Find(T value) => Find(value, true);

        public Node<T> FindLast(T value) => Find(value, false);

        private Node<T> Find(T value, bool nextOrPrevious) // true - next, previous - false
        {
            Node<T> currentNode = nextOrPrevious ? First : Last;
            while (currentNode != null)
            {
                if (currentNode.Value.GetHashCode() == value.GetHashCode())
                    return currentNode;
                currentNode = nextOrPrevious ? currentNode.nextNode : currentNode.previousNode;
            }
            return null;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currenNode = First;
            while (currenNode != null)
            {
                yield return currenNode.Value;
                currenNode = currenNode.nextNode;
            }
        }

        public void RemoveFirst() => RemoveNode(true);

        public void RemoveLast() => RemoveNode(false);

        private void RemoveNode(bool firstOrLast) // true - First, false - Last
        {
            if (Count == 0) throw new InvalidOperationException("The MyLinkedList<T> is empty");
            if (Count == 1)
            {
                First = null;
                Last = null;
            }
            else
            {
                if (firstOrLast)
                {
                    First = First.nextNode;
                    First.previousNode.nextNode = null;
                    First.previousNode = null;
                }
                else
                {
                    Last = Last.previousNode;
                    Last.nextNode.previousNode = null;
                    Last.nextNode = null;
                }
            }
            Count--;
        }

        public bool Remove(T value)
        {
            var deletedNode = Find(value);
            if (deletedNode != null)
            {
                deletedNode.previousNode.nextNode = deletedNode.nextNode;
                deletedNode.nextNode.previousNode = deletedNode.previousNode;
                Count--;
                return true;
            }
            return false;
        }
        #endregion

        

        #region private методы

        private Node<T> FindNode(Node<T> node) => FindNode(node, true);

        private Node<T> FindLastNode(Node<T> node) => FindNode(node, false);

        private Node<T> FindNode(Node<T> node, bool nextOrPrevious) // true - next, previous - false
        {
            Node<T> currentNode = nextOrPrevious ? First : Last;
            while (currentNode != null)
            {
                if (currentNode.Equals(nextOrPrevious ? node.nextNode : node.previousNode))
                    return currentNode;
                currentNode = nextOrPrevious ? currentNode.nextNode : currentNode.previousNode;
            }
            return null;
        }

        #endregion
    }
}
