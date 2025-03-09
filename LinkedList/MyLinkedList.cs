namespace LinkedList
{
    internal sealed class MyLinkedList<T>
    {
        private Node<T> first = null;
        private Node<T> last = null;
        private int count = 0;

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

        #region Методы
        public void AddFirst(T value)
        {
            var node = new Node<T>(value);
            AddFirst(node);
        }

        public void AddFirst(Node<T> node)
        {
            Count++;
            if (First != null)
            {
                node.nextNode = First;
                First = node;
                node.nextNode.previousNode = node;
            } 
            else
            {
                First = node;
                Last = node;
            }
        }

        public void AddLast(T value)
        {
            var node = new Node<T>(value);
            AddLast(node);
        }

        public void AddLast(Node<T> node)
        {
            Count++;
            if (Last != null)
            {
                node.previousNode = Last;
                Last = node;
                node.previousNode.nextNode = node;
            }
            else
            {
                First = node;
                Last = node;
            }
        }

        public bool Contains(T value) => Find(value) == null;

        public void Clear()
        {
            while (Count > 0)
                RemoveFirst();
        }

        public Node<T> Find(T value)
        {
            Node<T> currentNode = First;
            while (currentNode.nextNode != null)
            {
                if (currentNode.Value.GetHashCode() == value.GetHashCode())
                    return currentNode;
                currentNode = currentNode.nextNode;
            }
            return null;
        }

        public Node<T> FindLast(T value)
        {
            Node<T> currentNode = Last;
            while (currentNode.previousNode != null)
            {
                if (currentNode.Value.GetHashCode() == value.GetHashCode())
                    return currentNode;
                currentNode = currentNode.previousNode;
            }
            return null;
        }

        public void RemoveFirst()
        {
            if (Count == 0) throw new InvalidOperationException("The MyLinkedList<T> is empty");
            if (Count == 1)
            {
                First = null;
                Last = null;
            } 
            else 
            {
                First = First.nextNode;
                First.previousNode.nextNode = null;
                First.previousNode = null;
            }
            Count--;
        }

        public void RemoveLast()
        {
            if (Count == 0) throw new InvalidOperationException("The MyLinkedList<T> is empty");
            if (Count == 1)
            {
                First = null;
                Last = null;
            }
            else
            {
                Last = Last.previousNode;
                Last.nextNode.previousNode = null;
                Last.nextNode = null;
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
    }
}
