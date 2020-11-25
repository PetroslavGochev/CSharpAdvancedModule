using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    class Box<T>
        where T:IComparable<T>
    {
        public static int Return(T element, List<T> list)
        {
            return list
                .Where(x => x.CompareTo(element) > 0)
                .Count();
        }
    }
}
