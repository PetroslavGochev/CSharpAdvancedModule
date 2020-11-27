using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class CustomList
    {
        private const int INITIAL_CAPACITY = 2;
        private int[] items;
        public int Count { get; private set; }
        public CustomList()
        {
            this.items = new int[INITIAL_CAPACITY];
        }
        public int this[int index]
        {
            get
            {
                if (!isValid(index))
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (!isValid(index))
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
        }
        public bool isValid(int index)
            => index >= this.Count;
        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        public void Add(int element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
            this.items[this.Count] = element;
            this.Count++;
        }
        public int RemoveAt(int index)
        {
            if (isValid(index))
            {
                throw new ArgumentOutOfRangeException();
            }
            var item = this.items[index];
            this.items[index] = default(int);
            this.ShiftToLeft(index);
            this.Count--;
            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }
            return item;
        }
        private void ShiftToLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[index + 1];
            }
        }
        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }
            this.items = copy;
        }
        private void ShiftToRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        public void Insert(int index, int element)
        {
            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
            this.ShiftToRight(index);
            this.items[index] = element;
            this.Count++;
        }
        public bool Contains(int element)
        {
            foreach (var item in items)
            {
                if (element == item)
                {
                    return true;
                }
            }
            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex >= items.Length || secondIndex >= items.Length)
            {
                throw new ArgumentOutOfRangeException();
            }
            var temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        public override string ToString()
        {
            return $"{string.Join(" ", items)}";
        }
    }
}
