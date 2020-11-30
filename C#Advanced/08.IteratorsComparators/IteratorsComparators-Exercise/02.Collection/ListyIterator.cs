using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListyIterator
{
    class ListyIterator<T> : IEnumerable<T>
    {
        private int index;
        public ListyIterator(params T[] collection)
        {
            this.index = 0;
            this.Collection = new List<T>(collection);
        }
        public List<T> Collection { get; set; }
        public int Count => this.Collection.Count;
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public bool Move()
        {

            if (index + 1 >= this.Collection.Count)
            {
                return false;
            }
            index++;
            return true;
        }
        public void Print()
        {
            if (this.Collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.Collection[index]);

            }
        }
        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ", Collection));
        }
       
        public bool HashNext()
        {
            if (index < this.Count - 1)
            {
                return true;
            }
            return false;
        }
    }
}
