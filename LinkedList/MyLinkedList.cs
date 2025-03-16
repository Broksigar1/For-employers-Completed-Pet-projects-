﻿namespace LinkedList
{
    internal sealed class MyLinkedList<T> : IEnumerable<T>, ICollection<T>
    {
        private Node<T>? first = null;
        private Node<T>? last = null;
        private int count = 0;

        private enum Positions 
        {
            First,
            Last
        }

        #region Конструкторы

        public MyLinkedList() 
        {
        }

        public MyLinkedList(IEnumerable<T> sequence)
        {
            foreach (var value in sequence)
                AddLast(value);
        }

        #endregion

        #region Свойства

        public Node<T>? First
        {
            get
            {
                return first;
            }
            private set 
            {
                if ((Count > 1 && value?.previousNode != null) ||
                    (Count == 1 && (value?.nextNode != null || value?.previousNode != null)))
                    throw new ArgumentException();
                first = value;
            }
        }

        public Node<T>? Last
        {
            get
            {
                return last;
            }
            private set
            {
                if ((Count > 1 && value?.nextNode != null) ||
                    (Count == 1 && (value?.nextNode != null || value?.previousNode != null)))
                    throw new ArgumentException();
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
                if (count < 0)
                    throw new ArgumentException();
                count = value;
            }
        }

        #endregion

        #region Методы

        void ICollection<T>.Add(T value) => AddLast(value);

        public void AddAfter(Node<T> node, T value)
        {
            var newNode = new Node<T>(value);
            AddAfter(node, newNode);
        }

        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            if (node == null || newNode == null) throw new ArgumentNullException();

            if (newNode.nextNode != null || newNode.previousNode != null)
                throw new InvalidOperationException();

            Count++;
            if (node.Equals(Last))
            {
                Last = newNode;
                node.nextNode = newNode;
                newNode.previousNode = node;
            }
            else
            {
                newNode.previousNode = node;
                newNode.nextNode = node.nextNode;
                node.nextNode.previousNode = newNode;
                node.nextNode = newNode;
            }
        }

        public void AddBefore(Node<T> node, T value)
        {
            var newNode = new Node<T>(value);
            AddBefore(node, newNode);
        }

        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            if (node == null || newNode == null) throw new ArgumentNullException();

            if (newNode.nextNode != null || newNode.previousNode != null)
                throw new InvalidOperationException();

            Count++;
            if (node.Equals(First))
            {
                First = newNode;
                node.previousNode = newNode;
                newNode.nextNode = node;
            }
            else
            {
                newNode.nextNode = node;
                newNode.previousNode = node.previousNode;
                node.previousNode.nextNode = newNode;
                node.previousNode = newNode;
            }
        }

        public void AddFirst(T value) => AddNodeToPosition(new Node<T>(value), Positions.First);

        public void AddFirst(Node<T> node) => AddNodeToPosition(node, Positions.First);

        public void AddLast(T value) => AddNodeToPosition(new Node<T>(value), Positions.Last);

        public void AddLast(Node<T> node) => AddNodeToPosition(node, Positions.Last);

        private void AddNodeToPosition(Node<T> node, Positions pos)
        {
            Count++;
            if ((pos == Positions.First ? First : Last) != null)
            {
                if (pos == Positions.First)
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

        public Node<T>? Find(T value) => FindFromPosition(value, Positions.First);

        public Node<T>? FindLast(T value) => FindFromPosition(value, Positions.Last);

        private Node<T>? FindFromPosition(T value, Positions pos)
        {
            Node<T>? currentNode = pos == Positions.First ? First : Last;
            while (currentNode != null)
            {
                if (currentNode?.Value?.GetHashCode() == value?.GetHashCode())
                    return currentNode;
                currentNode = pos == Positions.First ? currentNode?.nextNode : currentNode?.previousNode;
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

        bool ICollection<T>.IsReadOnly => false;

        public void RemoveFirst() => RemoveAtPosition(Positions.First);

        public void RemoveLast() => RemoveAtPosition(Positions.Last);

        private void RemoveAtPosition(Positions pos)
        {
            if (Count == 0) throw new InvalidOperationException();
            if (Count == 1)
            {
                First = null;
                Last = null;
            }
            else
            {
                if (pos == Positions.First)
                {
                    First.nextNode.previousNode = null;
                    First = First?.nextNode;
                }
                else
                {
                    Last.previousNode.nextNode = null;
                    Last = Last?.previousNode;
                }
            }
            Count--;
        }

        public void Remove(Node<T> deletedNode)
        {
            if (deletedNode != null)
            {
                if (deletedNode.Equals(First))
                {
                    deletedNode.nextNode.previousNode = null;
                    First = deletedNode.nextNode ?? null;
                }

                if (deletedNode.Equals(Last))
                {
                    deletedNode.previousNode.nextNode = null;
                    Last = deletedNode.previousNode ?? null;
                }

                if (deletedNode.previousNode != null)
                {
                    deletedNode.previousNode.nextNode = deletedNode.nextNode;
                }

                if (deletedNode.nextNode != null)
                {
                    deletedNode.nextNode.previousNode = deletedNode.previousNode;
                }
                Count--;
            }
        }

        public bool Remove(T value)
        {
            var deletedNode = Find(value);

            if (deletedNode != null)
            {
                if (deletedNode.Equals(First))
                {
                    deletedNode.nextNode.previousNode = null;
                    First = deletedNode.nextNode ?? null;
                }

                if (deletedNode.Equals(Last))
                {
                    deletedNode.previousNode.nextNode = null;
                    Last = deletedNode.previousNode ?? null;
                }

                if (deletedNode.previousNode != null)
                {
                    deletedNode.previousNode.nextNode = deletedNode.nextNode;
                }

                if (deletedNode.nextNode != null)
                {
                    deletedNode.nextNode.previousNode = deletedNode.previousNode;
                }
                Count--;
                return true;
            }
            return false;
        }

        #endregion
    }
}
