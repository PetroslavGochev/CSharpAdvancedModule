using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        public ListNode Head { get; set; }
        public ListNode Tail { get; set; }
        public int Count { get; set; }

        public void AddFirst(int element)
        {
            if (Count == 0)
            {
                this.Head = this.Tail = new ListNode(element);
            }
            else
            {
                var newHead = new ListNode(element);
                newHead.Next = this.Head;
                this.Head.PreviousNode = newHead;
                this.Head = newHead;
            }
            this.Count++;

        }
        public void AddLast(int element)
        {
            if (this.Count == 0)
            {
                this.Head = this.Tail = new ListNode(element);
            }
            else
            {
                var newTail = new ListNode(element);
                newTail.Next = this.Tail;
                this.Tail.PreviousNode = this.Tail;
                this.Tail = newTail;
            }
            this.Count++;
        }
        public int RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("This list is empty");
            }
            var firstElement = this.Head.Value;
            this.Head = Head.Next;
            if (this.Head != null)
            {
                this.Head.PreviousNode = null;
            }
            else
            {
                this.Tail = null;
            }
            this.Count--;
            return firstElement;
        }
        public int RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("This list is empty");
            }
            var lastElement = this.Tail.Value;
            this.Tail = Tail.PreviousNode;
            if (this.Tail != null)
            {
                this.Tail.Next = null;
            }
            else
            {
                this.Head = null;
            }
            this.Count--;
            return lastElement;
        }
        public void ForEach(Action<int> action)
        {
            var currentNode = this.Head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
        public int[] ToArray()
        {
            int[] array = new int[this.Count];
            var currentNode = this.Head;
            int counter = 0;
            while(currentNode != null)
            {
                array[counter] = currentNode.Value;
                currentNode = currentNode.Next;
                counter++;
            }
            return array;
        }
        public void PrintList()
        {
            ListNode currentNode = Head;
            while(currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }
    }
}
