using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodInteger
{
    class Box<T>
    {
        public List<T> list { get; set; }
        public Box()
        {
            list = new List<T>();
        }
        public void GenericMethod(int first, int second)
        {
            var temp = this.list[first];
            this.list[first] = this.list[second];
            this.list[second] = temp;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (T item in list)
            {
                result.AppendLine($"{item.GetType()}: {item}");
            }
            return result.ToString().Trim();

        }
    }
}
