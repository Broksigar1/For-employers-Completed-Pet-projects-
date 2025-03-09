namespace LinkedList
{
    internal sealed class Node<T>
    {
        public Node<T> previousNode = null;
        public Node<T> nextNode = null;

        public Node(T value) => Value = value;

        public T Value
        {
            get;
            private set;
        }
    }
}
