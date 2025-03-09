namespace LinkedList
{
    internal sealed class Program
    {
        private static void Main()
        {
            var list = new MyLinkedList<int>();
            //Console.WriteLine(list.Count);
            //list.AddFirst(1);
            //list.AddFirst(2);
            //list.AddFirst(3);
            //Console.WriteLine(list.Count);
            //list.RemoveFirst();
            //list.RemoveFirst();
            //list.RemoveFirst();
            //Console.WriteLine(list.Count);

            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.Clear();
        }
    }
}
