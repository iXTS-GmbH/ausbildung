using NUnit.Framework;

namespace ixts.Ausbildung.Ring_Queue.Test
{
    [TestFixture]
    public class RingQueueTests
    {


        [TestCase(0,5)]
        public void SizeTest(int expected,int capacity)
        {
            var ring = new RingQueue<int>(capacity);

            var actual = ring.Size();

            Assert.AreEqual(expected,actual);
        }

        [TestCase(3,1,2,3,4,5,6)]
        public void PushGetTest(int capacity,params int[] values)
        {
            var ring = new RingQueue<int>(capacity);

            foreach (var value in values)
            {
                ring.Push(value);
            }

            Assert.AreEqual(values[5], ring.Get(0));
            Assert.AreEqual(values[4], ring.Get(1));
            Assert.AreEqual(values[3], ring.Get(2));

            for (var i = values.Length -1; i > values.Length - 4; i--)
            {
                Assert.AreEqual(values[i],ring.Get(values.Length -1 - i));
            }
        }

        [ExpectedException]
        [TestCase(1,2,3,4,5,6)]
        public void ClearTest(params int[] values)
        {
            var ring = new RingQueue<int>(values);

            ring.Clear();

            ring.Get(0);

        }
    }
}
