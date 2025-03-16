namespace LinkedList
{
    internal static class UtilsForTests
    {
        public static bool IsEmptyListHasCorrectFields<T>(MyLinkedList<T> list) => list.Count == 0 && list.First == null && list.Last == null;

        public static bool CheckOrder<T>(MyLinkedList<T> list, T[] expectedOrder)
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

        public static void FillListNumbersFrom1To5(MyLinkedList<int> list)
        {
            for (int i = 1; i <= 5; i++)
                list.AddLast(i);
        }
    }
}
