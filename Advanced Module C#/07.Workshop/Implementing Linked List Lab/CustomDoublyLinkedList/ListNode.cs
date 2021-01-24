using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class ListNode
    {
        public ListNode(int element)
        {
            this.Value = element;
        }
        public int Value { get; set; }
        public ListNode Next { get; set; } 
        public ListNode PreviousNode { get; set; } 
    }
}
