using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    class EqualityScale<T>
    {
        private T left;
        private T right;
        public EqualityScale(T left , T right)
        {
            this.left = left;
            this.left = left;
        }

        public bool AreEqual()
        {
            return left.Equals(right);
        }
        
    }
}
