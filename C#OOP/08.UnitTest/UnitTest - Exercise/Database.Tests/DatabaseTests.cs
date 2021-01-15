

namespace Tests
{
    using Database;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        private const int ARRAY_MAXIMUM = 16;
        private const int ARRAY_MINIMUM = 1;
        private const int ARRAY_OUT_OF_RANGE = 17;
        private int[] array;
        private int[] arrayOverCapacity;
        private Database dataBase;

        [SetUp]
        public void Setup()
        {
            this.array = Enumerable.Range(ARRAY_MINIMUM, ARRAY_MAXIMUM).ToArray();
            this.arrayOverCapacity = new int[ARRAY_OUT_OF_RANGE];
            dataBase = new Database(array);
        }
        [Test]
        public void TestedConstructor()
        {
            Assert.That(() => new Database(this.arrayOverCapacity), Throws.InvalidOperationException);
        }
        [Test]
        public void TestedAddMethod()
        {
            Assert.That(() => dataBase.Add(1),Throws.InvalidOperationException);
        }
        [Test]
        public void TestedRemoveEmptyArrayMethod()
        {
            dataBase = new Database();
            Assert.That(() => dataBase.Remove(), Throws.InvalidOperationException);
        }
        [Test]
        public void TestedRemoveMethod()
        {
            int expectResult = dataBase.Count - 1;
            dataBase.Remove();
            Assert.AreEqual(expectResult, dataBase.Count);
        }
        [Test]
        public void FetchTest()
        {
            int[] expectResult = new int[dataBase.Count];
            for (int i = 0; i < expectResult.Length; i++)
            {
                expectResult[i] = i+1;
            }
            int[] fetch = dataBase.Fetch();
            Assert.AreEqual(expectResult, fetch);
        }

    }
}