using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    class StackStructure<T> : IEnumerable<T>
    {
        private int count;
        public StackStructure()
        {
            this.Stacks = new List<T>();
        }
        public List<T> Stacks { get; set; }
        public void Push(T[] element)
        {
            foreach (var item in element)
            {
                this.Stacks.Add(item);
            }
            count += element.Length;
        }
        public void Pop()
        {
            if(count > 0)
            {
                this.Stacks.RemoveAt(this.count - 1);
                count--;
            }
            else
            {
                throw new InvalidOperationException("No elements");
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = count-1; i >= 0 ; i--)
            {
                yield return this.Stacks[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
