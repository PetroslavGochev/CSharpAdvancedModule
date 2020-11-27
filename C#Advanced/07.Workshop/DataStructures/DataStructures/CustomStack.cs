using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    class CustomStack
    {
        private const int INITIAL_CAPACITY = 4;
        private int[] items;
        private int count;
        public CustomStack()
        {
            this.count = 0;
            this.items = new int[INITIAL_CAPACITY];
        }
        public int Count
        {
            get
            {
                return this.count;
            }
        }
        public void Push(int element)
        {
            if (this.items.Length == this.count)
            {
                var nextItems = new int[this.items.Length * 2];
                for (int i = 0; i < this.items.Length; i++)
                {
                    nextItems[i] = this.items[i];
                }
                this.items = nextItems;
            }
            this.items[this.count] = element;
            count++;
        }
        public int Pop()
        {
            if (this.items.Length == 0)
            {
                throw new InvalidOperationException("Customstack is empty!");
            }
            var element = this.items[this.count - 1];
            this.items[this.count - 1] = default;
            this.count--;
            return element;
        }
        public int Peek()
            => this.items[this.count - 1];
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                action(this.items[i]);
            }
        }
    }
}
