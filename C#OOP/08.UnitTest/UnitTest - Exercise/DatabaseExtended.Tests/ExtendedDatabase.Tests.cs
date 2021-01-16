using NUnit.Framework;

namespace Tests
{
    using ExtendedDatabase;
    using System;

    public class ExtendedDatabaseTests
    {
        private Person[] arrayOverCapacity;
        private ExtendedDatabase edb;
        [SetUp]
        public void Setup()
        {
            arrayOverCapacity = new Person[17];
            this.edb = new ExtendedDatabase();
        }
        // Test Constructor
        [Test]
        public void ConstructorTestedIfArrayIsOverTheCapacity()
        {
            
            Assert.That(() => new ExtendedDatabase(arrayOverCapacity), Throws.ArgumentException);
        }
        [Test]
        public void ConstructorWorkedCorectly()
        {
            this.edb = new ExtendedDatabase(new Person(1, "Test"));
            Assert.IsNotNull(this.edb);
        }

        //Test Add Method
        [Test]
        public void AddMethodIfPersonAlreadyExist()
        {
            Person person = new Person(123121, "Gosho");
            Person person2 = new Person(1212, "Gosho");
            edb.Add(person);
            Assert.That(() => edb.Add(person2), Throws.InvalidOperationException);
        }
        [Test]
        public void AddMethodIfPersonIdAlreadyExist()
        {
            Person person = new Person(123121, "Gosho");
            Person person2 = new Person(123121, "Mitko");
            edb.Add(person);
            Assert.That(() => edb.Add(person2), Throws.InvalidOperationException);
        }
        [Test]
        public void AddMethodIfArrayIsMaximumCapacity()
        {
            Person[] person = new Person[16];
            for (int i = 0; i < person.Length; i++)
            {
                person[i] = new Person(i, $"Test{i}");
            }     
            Person personForAdd = new Person(1, "Invalid");
            this.edb = new ExtendedDatabase(person);
            Assert.That(() => edb.Add(personForAdd), Throws.InvalidOperationException);
        }

        //Test RemoveMethod
        [Test]
        public void RemoveMethodIfArrayIsEmpty()
        {
            Assert.That(() => edb.Remove(), Throws.InvalidOperationException);
        }
        [Test]
        public void RemoveMethod()
        {
            edb = new ExtendedDatabase(new Person(123, "Gosho"));
            int expectedCount = edb.Count - 1;
            edb.Remove();
            Assert.AreEqual(expectedCount,edb.Count);
        }

        //Test FindByUser
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void IsNameNullOrEmptyString(string name)
        {
            Assert.That(() => edb.FindByUsername(string.Empty), Throws.ArgumentNullException); 
        }
        [Test]
        public void NameDoesntExist()
        {
            Assert.That(() => edb.FindByUsername("Test"), Throws.InvalidOperationException);
        }
        [Test]
        public void IfNameExist()
        {
            Person person = new Person(12, "Test");
            edb = new ExtendedDatabase(person);
            Person expectedPerson = edb.FindByUsername("Test");
            Assert.AreEqual(expectedPerson,person);
        }

        //Test FindByID
        [Test]
        public void IsIDNegativeNumber()
        {             
            Assert.Throws<ArgumentOutOfRangeException>(() => edb.FindById(-2));
        }
        [Test]
        public void IdDoesntExist()
        {
            Assert.That(() => edb.FindById(1), Throws.InvalidOperationException);
        }
        [Test]
        public void IfIdExist()
        {
            Person person = new Person(12, "Test");
            edb = new ExtendedDatabase(person);
            Person expectedPerson = edb.FindById(12);
            Assert.AreEqual(expectedPerson, person);
        }

        //TestFetch
        [Test]
        public void FetchTest()
        {
            Person first = new Person(1, "Test");

            Person[] expectResult = new Person[1] { first };
            edb = new ExtendedDatabase(first);
            Person[] person = new Person[1] { edb.FindById(1) };
            Assert.AreEqual(expectResult, person);
        }

    }
}