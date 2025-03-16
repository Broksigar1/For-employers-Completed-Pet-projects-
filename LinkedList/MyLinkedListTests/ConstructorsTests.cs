using NUnit.Framework;

namespace LinkedList
{
    [TestFixture]
    internal sealed class ConstructorsTests
    {
        [Test]
        public void CreateListFromSequence()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5 };
            IEnumerable<int> sequence = arr.Select(num => num);

            var list = new MyLinkedList<int>(sequence);
            var i = 1;
            foreach (var num in list)
            {
                Assert.That(num, Is.EqualTo(i));
                i++;
            }
        }
    }
}
